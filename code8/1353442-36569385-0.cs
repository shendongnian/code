	public async Task AwaitOnTaskAsync()
	{
		try
		{
			await DoStuffWithThreadAsync();
		}
		catch (Exception e)
		{
		}
	}
	
	public Task DoStuffWithThreadAsync()
	{
		return Task.Run(() => { throw new Exception("blabla"); });
	}
	
