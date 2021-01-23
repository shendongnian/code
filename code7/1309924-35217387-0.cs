    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    dispatcherTimer.Interval = new TimeSpan(0, 10, 0);
    dispatcherTimer.Tick += timer_Tick;
    private void timer_Tick(object sender, EventArgs e)
    {
               //your save db code
    }
