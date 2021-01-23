	public consoleForm()
	{
		var timer = new Systems.Timers.Timer(100); // Create a timer that fires every 100ms (0.1s)
		timer.Tick += OnTimer_Tick;
		timer.Start();
	}
