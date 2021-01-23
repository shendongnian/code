	private CancellationTokenSource cts = new CancellationTokenSource();
	public async Task LoadPageOneAsync()
	{
		try
		{
			await InitializePageOneDataAsync(cts.Token)
		}
		catch (OperationCanceledException e)
		{
			// Handle if needed.
		}
	}
	
	public async Task InitializePageOneDataAsync(CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		foreach (var something in collection)
		{
			cancellationToken.ThrowIfCancellationRequested();
			// Do other stuff
		}	
	}
	
