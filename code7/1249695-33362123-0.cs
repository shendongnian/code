	public async Task FooAsync()
	{
		string result = await RunSlowOperation();
		Console.WriteLine(result);
	}
