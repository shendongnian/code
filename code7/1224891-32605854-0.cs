    private System.Timers.Timer timer;
    
    public void updateCycle50ms( )
    {
        // Create a timer with a 50ms interval.
        timer= new System.Timers.Timer(50);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += (s, e) =>
        {
            // Sending Message
            CANSEND(ref msg);
        };
        // Have the timer fire repeated events (true is the default)
        timer.AutoReset = true;
        // Start the timer
        timer.Enabled = true;
        // If the timer is declared in a long-running method, use KeepAlive to prevent garbage collection
        // from occurring before the method ends. 
        // GC.KeepAlive(timer)
    }
