﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy_1 extends the Enemy class
public class Enemy_1 : Enemy {

    [Header("Set in Inspector: Enemy_1")]

    //# seconds for a full sine wave
    public float waveFrequency = 2;
    // sine wave width in meters
    public float waveWidth = 4;
    public float waveRotY = 45;

    private float x0;

    //the inital x value of pos

    private float birthTime;
    //starts work well b/c not used by enemy superclass


    // Use this for initialization
    void Start()
    {
        //set x0 to the initial x position of Enemy_1
        x0 = pos.x;

        //b

        birthTime = Time.time;

    }

    // Override the Move function on Enemy
    // make sure to read the section on what is needed to override a function

    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        //rotate a bit about y 
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        //base.Move() still handles the movement down in y
        base.Move();

        

}

    }


