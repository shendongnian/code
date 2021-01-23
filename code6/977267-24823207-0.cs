    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        var timer = (System.Timers.Timer)sender;
        timer.Dispose(); //here
    }
