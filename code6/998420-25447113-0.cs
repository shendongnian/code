    private DispatcherTimer timer = new DispatcherTimer();
    private isMouseOver = false;
...
    timer.Interval = TimeSpan.FromMilliseconds(400);
    timer.Tick += Timer_Tick;
