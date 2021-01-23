    private System.Timers.Timer timer;
    
    protected override void OnStart(string[] args)
    {
        timer = new System.Timers.Timer();
        timer.Interval = 10000;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
        timer.Start();
    }
    
    protected override void OnStop()
    {
        timer.Stop();
        timer = null;
    }
