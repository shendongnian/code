    protected override void OnStart(string[] args)
    {
        // Set up timer
        int initialIntervalSync = 10; // 10 seconds
        timer = new System.Timers.Timer();
        timer.Interval = initialIntervalSync * 1000;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
        timer.Start();    
    }
    
    public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
    {
        //Reset timer interval
        int intervalSync = 14400; // 4 hours default
        timer.Interval = intervalSync * 1000;
        
        this.DoMigration();
    }
