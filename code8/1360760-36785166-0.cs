    public static System.Timers.Timer myTimer = new System.Timers.Timer();    
    private void Controllel_Opened(object sender, EventArgs e)
    {   
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(DisplayTimeEvent);
        myTimer.Interval = 1000; // 1000 ms is one second
        myTimer.Start();
    }
    public static void DisplayTimeEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        // code here will run every second
    }
