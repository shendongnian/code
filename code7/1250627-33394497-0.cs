	void Main()
	{
		var actionBlock = new ActionBlock<int>(
				i => Console.WriteLine(i), 
				new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 16});
		
		foreach (var i in Enumerable.Range(0, 200))
		{
			actionBlock.Post(i);
		}
	}
	
