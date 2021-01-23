    private DispatcherTimer _timer = new DispatcherTimer();
    private Random rand = new Random();
    
    public void InitAndStartTimer()
    {
    	_timer.Tick += dispatcherTimer_Tick;
    	_timer.Interval = TimeSpan.FromSeconds(rand.Next(1, 10)); // From 1 s to 10 s
        _timer.Start();
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
    	_timer.Interval = TimeSpan.FromSeconds(rand.Next(1, 10)); // From 1 s to 10 s
    	// Do your work.
    }
