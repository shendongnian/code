    private DispatcherTimer _timer;
    private Random rand = new Random();
    
    public void StartTimer()
    {
    	_timer = new DispatcherTimer();
    	_timer.Tick += dispatcherTimer_Tick;
    	_timer.Interval = rand.Next(1000, 3000); // From 1000 ms to 3000 ms
    	mytimer.Enabled = true;
        mytimer.Start();
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
    	_timer.Interval = rand.Next(1000, 3000); // From 1000 ms to 3000 ms
    	// Do your work.
    }
