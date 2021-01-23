    public Ctor()
    {
          _timer = new System.Timers.Timer(timeout);
          _timer.AutoReset = false;
          _timer.Elapsed += Timer_Elapsed;
          _timer.Start();
    }
        
    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // your code here runs after the timeout elapsed
    }
