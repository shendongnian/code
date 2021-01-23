    private int myNumber;
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	base.OnNavigatedTo(e);
    	string QueryStr = "";
    	NavigationContext.QueryString.TryGetValue("myNumber", out QueryStr);
    	myNumber = (int.Parse(QueryStr));
    	
    	DispatcherTimer newTimer = new DispatcherTimer();
    	newTimer.Interval = TimeSpan.FromSeconds(1);
    	//attach event handler method for Tick event
    	newTimer.Tick += OnTimerTick;
    	//or attach anonymous method so you don't need OnTimerTick() method :
    	//newTimer.Tick += (o, e) => { myNumber++; };
    	newTimer.Start();
    }
    
    void OnTimerTick(Object sender, EventArgs args)
    {
    	myNumber++;
    }
