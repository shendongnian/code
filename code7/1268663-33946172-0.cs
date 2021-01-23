    public static void Main(string[] args)
    {
        timer = new System.Timers.Timer(1000); // 1 seconds
        timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
    
        timer.Interval = 1000;
        timer.Enabled = true;
    
        Console.WriteLine("Press the enter key to stop the timer");
        Console.ReadLine();
    }
    
    private static void OnTimerElapsed(object source, ElapsedEventArgs e){
      Console.WriteLine("Timer elapsed at {0}", e.SignalTime);
    }
