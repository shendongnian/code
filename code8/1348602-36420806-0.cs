     void Start()
     {
         Input.gyro.enabled = true;
     }
    bool firstRun = true;
    float counter = 0;
    float calcTime = 1; //Find highest gyro value  every 1 seconds
    Vector3 oldGyroValue = Vector3.zero;
    Vector3 highestGyroValue = Vector3.zero;
        void Update()
        {
            gyroFrame();
        }
        void gyroFrame()
        {
    
            if (firstRun)
            {
                firstRun = false; //Set to false so that this if statement wont run again
                oldGyroValue = Input.gyro.userAcceleration;
                counter += Time.deltaTime; //Increment the timer to reach calcTime
                return; //Exit on first run because there is no old value
            }
    
            //Check if we have not reached the calcTime seconds 
            if (counter <= calcTime)
            {
                Vector3 tempVector = Input.gyro.userAcceleration;
                //Check if we have to Update X, Y, Z
                if (tempVector.x > oldGyroValue.x)
                {
                    oldGyroValue.x = tempVector.x;
                }
    
                if (tempVector.y > oldGyroValue.y)
                {
                    oldGyroValue.y = tempVector.y;
                }
    
                if (tempVector.z > oldGyroValue.z)
                {
                    oldGyroValue.z = tempVector.z;
                }
                counter += Time.deltaTime;
            }
    
            //We have reached the end of timer. Reset counter then get the highest value
            else
            {
                counter = 0;
                highestGyroValue = oldGyroValue;
                Debug.Log("The Highest Values for X: " + highestGyroValue.x + "  Y: " + highestGyroValue.y +
                    "  Z: " + highestGyroValue.z);
            }
        }
