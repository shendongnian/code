    private System.Timers.Timer _timer;
    _timer = new System.Timers.Timer();
    _timer.Interval = 1000;
    _timer.AutoReset = false;       // Fires only once! Has to be restarted explicitly
    _timer.Elapsed += MyTimerEvent;
    _timer.Start();
    private void MyTimerEvent(object source, ElapsedEventArgs e)
    {
        DateTime now = DateTime.Now;
        
        // Check for tasks to be run at this point of time and run them
        ...
        // Don't forget to restart the timer
        _timer.Start();
    }
