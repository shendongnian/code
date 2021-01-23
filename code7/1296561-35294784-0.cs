    static void Main(string[] args)
            {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 300000; // 30 minutes
            timer.Elapsed += new ElapsedEventHandler(serverCall);
            timer.AutoReset = true;
            timer.Start();
    
            System.Timers.Timer alerttimer = new System.Timers.Timer();
            alerttimer.Interval = 300000; // 30 minutes
            alerttimer.Elapsed += new ElapsedEventHandler(perfAlert);
            alerttimer.AutoReset = true;
            alerttimer.Start();
            }
