    int MIN = 0;
    int MAX = 100;
    public bool flipDirection = false;
    public bool smoothAccelerometer = true;
    
    float defaultZValue;
    
    //Filter Accelerometer
    float AccelerometerUpdateInterval = 1.0f / 30.0f;
    float LowPassKernelWidthInSeconds = 1.0f;
    float LowPassFilterFactor = 0;
    Vector3 lowPassValue = Vector3.zero;
    
    void Start()
    {
        defaultZValue = transform.position.z;
    
        //Filter Accelerometer
        LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
        lowPassValue = Input.acceleration;
    }
    
    
    void Update()
    {
        //Move Object
        transform.Translate(Vector3.forward * Time.deltaTime);
    
        //Get smoothed Accelerometer value values (pass in false to use raw Accelerometer values)
        Vector3 dir = LowPassFilterAccelerometer(smoothAccelerometer);
    
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            //Check if right
            if (dir.x > 0)
            {
                float angle = mapValue(dir.x, 0f, 1f, MIN, MAX);
                if (flipDirection)
                {
                    angle = angle * -1;
                }
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            //Check if left
            else if (dir.x < 0)
            {
                float angle = mapValue(dir.x, -0f, -1f, -MIN, -MAX);
                if (flipDirection)
                {
                    angle = angle * -1;
                }
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            //Middle(No direction)
            else
            {
                //Use Default Angle
                transform.localRotation = Quaternion.Euler(0, 0, defaultZValue);
            }
        }
    }
    
    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
    
    //Filter Accelerometer
    Vector3 LowPassFilterAccelerometer(bool smooth)
    {
        if (smooth)
            lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
        else
            lowPassValue = Input.acceleration;
    
        return lowPassValue;
    }
