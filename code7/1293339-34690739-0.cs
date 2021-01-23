	for (int i = 0; i < 100; i++)
	{
		ParallelOptions ops = new ParallelOptions();
		ops.MaxDegreeOfParallelism = Environment.ProcessorCount;
		
		var partitioner = Partitioner.Create<int>(Enumerable.Range(1, 5000));
	
		var watch = Stopwatch.StartNew();
		Parallel.ForEach<int>(partitioner, ops, x => { Thread.Sleep(1); });
		watch.Stop();
		Console.WriteLine("Parallel: {0}", watch.Elapsed.TotalSeconds);
	
		watch = Stopwatch.StartNew();
		foreach (var x in Enumerable.Range(1, 5000))
		{
			Thread.Sleep(1);
		}
		watch.Stop();
		Console.WriteLine("Non-parallel: {0}\n", watch.Elapsed.TotalSeconds);
	}
