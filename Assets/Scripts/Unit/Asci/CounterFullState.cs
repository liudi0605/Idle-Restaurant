using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterFullState : AsciState
{
    float timeOffset = .3f;
    float timeOffsetTemp;
    public override void StartState(Action action)
    {
        asci.bekleImage.gameObject.SetActive(true);
        action.Idle();
    }
    public override void UpdateState(Action action)
    {
        if(!asci.counter.isFull)
        {
            timeOffsetTemp += Time.deltaTime;
            if(timeOffsetTemp < timeOffset)
            {
                return;
            }
            timeOffsetTemp = 0;
            asci.pizza.transform.SetParent(null);
            asci.pizza.transform.position = asci.counter.tabakYerleri[asci.counter.tabakSayisi-1].position;
            asci.counter.food = asci.pizza;
            asci.counter.isFull = true;
            asci.level.restaurant.yemegiHazirCounterler.Add(asci.counter);  
            asci.pizza.transform.rotation = Quaternion.Euler(new Vector3(-90,0,0));
            asci.counter.UpdateQueue(asci);
            asci.currState = asci.buzdolabiState;
            asci.counter.UpdateQueue(asci);
            asci.bekleImage.gameObject.SetActive(false);
            asci.currState = asci.buzdolabiState;
        }
    }
}