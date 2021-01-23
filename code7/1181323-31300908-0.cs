    private System.Timers.Timer timer = new System.Timers.Timer();
    public MyObject()
    {
        timer.Elapsed += new ElapsedEventHandler(capturecolor_timer);
        timer.Interval = 5000;
    }
