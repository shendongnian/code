    public float rate = 1.0f;
    protected float power = 0f;
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp (KeyCode.Space))
        {
            UsePower(power);
            power = 0f;
        }
        if (Input.GetKey (KeyCode.Space))
        {
            power += rate * Time.deltaTime;
        }
    }
    void UsePower (float _power)
    {
        // Use power here
    }
