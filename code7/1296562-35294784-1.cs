    static void Main(string[] args)
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 300000; // 30 minutes
        timer.Elapsed += new ElapsedEventHandler(serverCall);
        timer.AutoReset = true;
        timer.Start();
    }
        
