    void _PersonUnlimitedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (exiting)
            return;
        try
        {
            string time = person.TimerTime;
            if (lblTime.InvokeRequired)
            {
                lblTime.Invoke(new Action(() => lblTime.Text = time));
            }
            else
            {
                lblTime.Text = time;
            }
        }
        catch 
        {
        }
    }
