    if (Input.GetKey(KeyCode.Space))
    {
        RearRight.brakeTorque = braking;
        RearLeft.brakeTorque = braking;
        speed -= 0.05f;
    
    }
    else if (speed <= maxspeed)
    {
       Debug.Log(speed);
       //this code makes car go forward
       RearRight.motorTorque = Input.GetAxis("Vertical") * speed;
       RearLeft.motorTorque = Input.GetAxis("Vertical") * speed;
       speed += 0.05f;
    }
