    public float avgFrameRate;
    public void Update()
    {
        avgFrameRate = Time.frameCount / Time.time;
    }
