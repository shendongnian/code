	public async Task ExecuteAndTimeoutAsync()
	{
		var canceller = new CancellationTokenSource();
		var tasks = new[]
		{
			Task.Run(async () =>
			{
				await Task.Delay(2000, canceller.Token);
				if (canceller.Token.IsCancellationRequested)
					return -1;
	
				Console.WriteLine("{0}: {1}", DateTime.Now, 3);
				return 3;
			}, canceller.Token),
			Task.Run(async () =>
			{
				await Task.Delay(5000, canceller.Token);
				if (canceller.Token.IsCancellationRequested)
					return -1;
	
				Console.WriteLine("{0}: {1}", DateTime.Now, 2);
				return 2;
			}, canceller.Token)
		};
	
		await Task.Delay(3000);
		canceller.Cancel();
		
		await Task.WhenAll(tasks);
	}
		
