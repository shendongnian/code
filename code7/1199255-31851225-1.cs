    private int FrameCounter = 0;
    private int Fps = 0;
    void Start() 
    {
        InvokeRepeating("CountFps", 0f, 1f);
    }
    void Update()
    {
        FrameCounter++;
    }
    private void CountFps()
    {
        Fps = FrameCounter;
        FrameCounter = 0;
    }
