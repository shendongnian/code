	public async Task FooAsync()
	{
		int value = await Task.Run(() => DoSomething());
	}
	
