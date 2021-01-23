    public float maxAngle = 325f; // Max Angle for Z Axis
    public float minAngle = 30f; // Min Angle for Z Axis
    public float rotationDelta = 1f; // you can control your rotation speed using this
    float tempAngle;
    void Update() 
    {
        // If AirPlane is rising, velocity in y is greater than 0
        if(rigidbody2D.velocity.y > 0)
        {
            tempAngle = Mathf.LerpAngle(transform.eulerAngles.z, maxAngle, Time.time * rotationDelta);
        }
        // If AirPlane is falling, velocity in y is less than 0
        else if(rigidbody2D.velocity.y < 0)
        {
            tempAngle = Mathf.LerpAngle(transform.eulerAngles.z, minAngle, Time.time * rotationDelta);
        }
        // If AirPlane is going straight in horizontal.
        else
        {
            tempAngle = 0;
        }
        transform.eulerAngles = new Vector3(0, 0, tempAngle);
    }
