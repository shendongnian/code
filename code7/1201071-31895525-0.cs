    // Declare a timer
    Timer tmr = new Timer();
    tmr.Interval = 10000; // 10 second
    tmr.Tick += timerHandler; // We'll write it in a bit
    tmr.Start(); // The countdown is launched!
    private void timerHandler(object sender, EventArgs e) {
        // Here the code what you need each 10 seconds
        tmr.Stop(); // Manually stop timer, or let run indefinitely
    }
