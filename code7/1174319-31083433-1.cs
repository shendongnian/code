    public float topSpeed;
    public float decelRate;
    protected bool slowDown = false;
    public void Update()
    {
        float speed = wheel.angularVelocity.magnitude;
        if (speed >= topSpeed) slowDown = true;
        if (slowDown)
        {
            speed -= decelRate * Time.deltaTime;
            wheel.angularVelocity = wheel.angularVelocity.normalized * speed;
        }
    }
