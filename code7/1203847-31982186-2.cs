    public static void Main()
    {
        var timer = new System.Timers.Timer()
       {
      
        Elapsed += new ElapsedEventHandler(OnTimedEvent),
        Interval = 5000,
        Enabled = true
       }
    }
    
     private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
        //your timer is executing
         myImageBox.Visible = !myImageBox.Visible
     }
