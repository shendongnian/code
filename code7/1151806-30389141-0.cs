	var timer = new System.Timers.Timer();
	timer.AutoReset = false;
	timer.Interval =
		new DateTime(2015, 5, 22, 15, 6, 0)
			.Subtract(DateTime.Now)
			.TotalMilliseconds;
	
	System.Timers.ElapsedEventHandler handler = null;
	handler = (s, e) =>
	{
		Notifier.OnNotify();
		timer.Elapsed -= handler;
		timer.Stop();
		timer.Dispose();
	};
	timer.Elapsed += handler;
	
	timer.Start();
