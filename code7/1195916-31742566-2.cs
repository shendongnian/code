    private int seconds;
    private int minutes;
    private int hours;
    private DispatcherTimer myTimer = new DispatcherTimer();
    private void Initialize()
    {
        myTimer.Interval = TimeSpan.FromMilliseconds(1000);
        myTimer.Tick += Each_Tick;
    }
    private void Tick_Timer_Start(object sender, RoutedEventArgs e)
    {
        myTimer.Stop();
        seconds = 0;
        minutes = 0;
        Timertext.Text = "0 minutes : 0 seconds";
        myTimer.Start();
    }
    private void Tick_Timer_Stop(object sender, RoutedEventArgs e)
    {
        myTimer.Stop();
    }
    private void Each_Tick(object o, EventArgs sender)
    {
        ...
    }
