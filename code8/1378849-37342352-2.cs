    void _PersonUnlimitedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {    
        if (exiting)
            return;
        // CHECK IF FORM IS ALREADY DISPOSED
        if (IsDisposed) return;
        string time = person.TimerTime;
        if (lblTime.InvokeRequired)
        //...
