	public async Task DoSomething()
	{
		var task = Interlocked.Exchange(ref _Task, null);
		
		if (task != null)
			await task;
	}
	
