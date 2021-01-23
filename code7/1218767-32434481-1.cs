	async Task Main()
	{
		var foo = FooAsync();
		await foo;
		await foo;
		
		var bar = BarAsync();
		var firstResult = await bar;
		var secondResult = await bar;
		
		Console.WriteLine(firstResult);
		Console.WriteLine(secondResult);
	}
	
	public async Task FooAsync()
	{
		await Task.Delay(1);
	}
	
	public async Task<int> BarAsync()
	{
		await Task.Delay(1);
		return 1;
	}
	
