    public void GetTime()
    {
        var now = DateTime.Now;
        Hours = now.Hour;
        Minutes = now.Minute;
        Seconds = now.Second;
        Frames = (now.Millisecond * 24) / 1000;
    }
