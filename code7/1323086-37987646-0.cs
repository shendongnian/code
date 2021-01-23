    private float timer;
    void Start()
    {
        timer = 2f; // Waiting 2 seconds between blinks
    }
    void Update()
    {
        timer -= Time.deltaTime;  // Consistently decrement timer independently of frame rate
        if (timer <= 0)
        {
            blinkLight();
            timer = 2f;
        }
    }
    void blinkLight()
    {
        // Light blinking logic goes here.
    }
