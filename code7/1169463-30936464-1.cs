    static System.Timers.Timer delay = new System.Timers.Timer();
    static AutoResetEvent reset = new AutoResetEvent(false);
    private static void InitTimer()
    {
        delay.Interval = 100;
        delay.Elapsed += OnTimedEvent;
        delay.Enabled = false;
    }
    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        ((System.Timers.Timer)sender).Enabled = false;
        reset.Set();
    }
    static void PrintSlowly2(string print)
    {
        InitTimer();
        foreach (char l in print)
        {
            Console.Write(l);
            delay.Enabled = true;
            reset.WaitOne();
        }
        Console.Write("\n");
    }
