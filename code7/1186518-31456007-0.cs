    System.Timers.Timer aTimer = new System.Timers.Timer();
    public static void Main()
    {        
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 1000 * 60 * 15;  //1 second * 60 seconds in a minute * 15 minutes
        aTimer.Enabled = true;
    }
