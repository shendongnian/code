	public int DoSomething() { return 42; }
	public async Task FooAsync()
	{
		int value = await Task.Factory.StartNew(
							() => DoSomething(), TaskCreationOptions.LongRunning);
	}
	
