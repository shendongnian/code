	var tokenSource = new CancellationTokenSource();
	var token = tokenSource.Token;
	var t = Task.Run(() =>
	{
		while (!token.IsCancellationRequested)
		{
			Console.Write(".");
			Thread.Sleep(500);
		}
	}, token);
	
	var timer = new System.Timers.Timer();
	timer.Interval = 5000;
	timer.Elapsed += (s, e) => tokenSource.Cancel();
	timer.Enabled = true;
