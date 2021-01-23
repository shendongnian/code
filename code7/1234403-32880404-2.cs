    static void Main()
    {
       System.Timers.Timer timer = new System.Timers.Timer();
       timer.Elapsed += OnElapseTime;
       timer.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
       timer.Start();
    }
    static void OnElapseTime(object sender, System.Timers.ElapsedEventArgs e)
    {
        var timer = (System.Timers.Timer)sender;
        timer.Stop();  // stop the timer after first run
        // do the work.. (be careful, this is running on a background thread)
        Console.WriteLine("Timer ticked...");
        Console.ReadLine();            
    } 
