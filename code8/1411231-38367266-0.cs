    var timer = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
    
    timer.Elapsed += Timer_Elapsed;
    
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // call the function that takes the screenshot
    }
