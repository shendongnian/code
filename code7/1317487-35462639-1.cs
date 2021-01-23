	var tasks = new[]
	{
		tasks.Add(Task.Run(async () => 
		{ 
			await Task.Delay(1000, canceller.Token);
			if (canceller.Token.IsCancellationRequested)
				return -1;
				
			Console.WriteLine("{0}: {1}", DateTime.Now, 3); 
			return 3; 
		}, canceller.Token)),
		tasks.Add(Task.Run(async () => 
		{ 
			await Task.Delay(2000, canceller.Token);
			if (canceller.Token.IsCancellationRequested)
				return -1;
				
			Console.WriteLine("{0}: {1}", DateTime.Now, 2); 
			return 2; 
		}, canceller.Token))
	}
	bool areAllTasksDone = Task.WaitAll(tasks, 3000);
	if (!areAllTasksDone)
		canceller.Cancel();
	
