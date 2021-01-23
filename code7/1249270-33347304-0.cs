	public async Task FooAsync()
	{
		var tasks = new[] { Task.Delay(1000), Task.Delay(2000), Task.Delay(500) };
		await Task.WhenAll(tasks);
		Console.WriteLine("Done").
	}
