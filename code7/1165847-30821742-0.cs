    protected void OnStartButtonClicked (object sender, EventArgs e)
    {
        stopwatch.Start ();
        // the next 3 lines could also be in the constructor function
        timer = new System.Timers.Timer();
        timer.Elapsed += new ElapsedEventHandler (timerTick);
        timer.Interval = 100;
        timer.Start ();
        Console.WriteLine ("Timer started");
    }
    protected void OnStopButtonClicked (object sender, EventArgs e)
    {
        timer.Stop ();
        stopwatch.Stop ();
        Console.WriteLine ("Timer stopped"); 
    }
    void timerTick(object sender, EventArgs e)
    {
        timeLabel.Text = stopwatch.Elapsed.ToString ();
    }
