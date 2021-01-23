    public static void Main()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval=5000;
        aTimer.Enabled=true;
    }
    
     private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
        //your timer is executing
         myImageBox.Visible = !myImageBox.Visible
     }
