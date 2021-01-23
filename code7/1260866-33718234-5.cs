	void Main()
	{
		TestAsync().Wait();
	}
	
	public async Task FooAsync()
	{
		int y = 0;
		await Task.Delay(5);
		Console.WriteLine($"After awaiting in FooAsync:
							{Thread.CurrentThread.ManagedThreadId }");
	
		while (y < 5) y++;
	}
	
	public async Task TestAsync()
	{
		Console.WriteLine($"Before awaiting in TestAsync:
			{Thread.CurrentThread.ManagedThreadId }");
		Task task = foo();
		int i = 0;
		while (i < 100)
		{
			var x = i++;
		}
	
		await task;
		Console.WriteLine($"After awaiting in TestAsync:
							{Thread.CurrentThread.ManagedThreadId }");
	}
	
