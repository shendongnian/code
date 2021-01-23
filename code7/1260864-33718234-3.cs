	async Task FooAsync()
	{
		int y = 0;
		await Task.Delay(5);
		
		Console.WriteLine("Thread-Pool threads after first await:");
		int avaliableWorkers;
		int avaliableIo;
		ThreadPool.GetAvailableThreads(out avaliableWorkers, out avaliableIo);
		Console.WriteLine($"Available Workers: { avaliableWorkers}, Available IO: { avaliableIo }");
	
		while (y < 1000000000) y++;
	}
	
	async Task TestAsync()
	{
		int avaliableWorkers;
		int avaliableIo;
		ThreadPool.GetAvailableThreads(out avaliableWorkers, out avaliableIo);
		
		Console.WriteLine("Thread-Pool threads before first await:");
		Console.WriteLine($"Available Workers: { avaliableWorkers}, Available IO: { avaliableIo }");
		Console.WriteLine("-------------------------------------------------------------");
		
		Task task = FooAsync();
		
		int i = 0;
		while (i < 100)
		{
			var x = i++;
		}
	
		await task;
	}
	
