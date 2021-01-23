    private DispatcherTimer timer = new DispatcherTimer();
...
    private void ResetTimer()
    {
        timer.Interval = TimeSpan.FromSeconds(20);
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        ResetDisplayData();
    }
