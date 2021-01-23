    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
    aTimer.Interval=3000;
    aTimer.Enabled=true;
 
    // Specify what you want to happen when the Elapsed event is raised.
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
         //add new data
    }
