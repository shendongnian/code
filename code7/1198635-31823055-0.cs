    private static long lastTime = System.Environment.TickCount;
    private static int fps = 1;
    private static int frames;
    private static float deltaTime = 0.005f;
    public static void Update()
    {
        var currentTick = System.Environment.TickCount;
        if(currentTick  - lastTime >= 1000)
        {
            fps = frames;
            frames = 0;
            lastTime = currentTick ;
        }
        frames++;
        deltaTime = currentTick  - lastTime;
    }
    public static int getFPS()
    {
        return fps;
    }
    public static float getDeltaTime()
    {
        return (deltaTime / 1000.0f);
    }
