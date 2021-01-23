    public void StartTimer()
    {
        _countdownTimer = new System.Timers.Timer(1000); // 1000 is the number of milliseconds
                                                         // 1000ms = 1 second
        // Set a handler for when the timer "ticks"
        // The "Tick" event will be fired after 1 second (as we've set it)
        // The timer will loop, though and keep firing until we stop it
        // Or unless it is set to not automatically restart
        _countdownTimer.Tick += OnTimer_Tick;
        // Start the timer!
        _countdownTimer.Start();
    }
