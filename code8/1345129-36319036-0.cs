    float maxAcceleration = 10;
    // Basically x = (1 / (2 * y))^2, but in code
    float CalculateAccGivenSpeed(float speed)
    {
        // Early exit so we don't bother with undefined results from dividing by 0
        if (speed == 0)
        {
            return Mathf.Infinity;
        }
        float rootAcc = 1 / (2 * speed);
        return rootAcc * rootAcc;
    }
    
    void FixedUpdate()
    {
        // Only accelerate if speed is lower than maximum allowed
        if (rb.velocity.magnitude < maxSpeed)
        {
            float allowableAcc = CalculateAccGivenSpeed(rb.velocity.magnitude);
            // Constrain acceleration here so rigidbody doesn't explode from stationary
            allowableAcc = Mathf.Min(maxAcceleration, allowableAcc);
            // Using ForceMode.Acceleration so we don't have to worry about mass
            rb.AddForce(transform.forward * allowableAcc, ForceMode.Acceleration);
        }
    }
