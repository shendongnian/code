        float vertical = Input.GetAxis("Vertical");
        if ((speed != 0 && speed <= maxspeed) || 
            (speed == 0.0 && vertical > 0.0))
        {
            Debug.Log(speed);
            //this code makes car go forward
            RearRight.motorTorque = vertical * speed;
            RearLeft.motorTorque = vertical * speed;
            speed += 0.05f;
        }
