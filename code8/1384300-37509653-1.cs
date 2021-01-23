    static void Main(string[] args)
    {
       System.Timers.Timer aTimer = new System.Timers.Timer();
       aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
       aTimer.Interval=360000;
       aTimer.Enabled=true;
       while(true) { }
    }
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
         // Do your stuff
         retriveEvents();
    }
