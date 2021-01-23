	private ConcurrentDictionary<string, CancellationTokenSource> pathsToTokens = 
						new ConcurrentDictionary<string, CancellationTokenSource>();
	
	protected async void SetDescPointAsync(object sender, EventArgs e)
	{
		CancellationTokenSource existingTokenSource;
		var path = UniquePath();
		if (pathsToTokens.TryGetValue(path, out existingTokenSource))
		{
			existingTokenSource.Cancel();
		}
		
		var cancellationTokenSource = new CancellationTokenSource();
		pathsToTokens.AddOrUpdate(path, cancellationTokenSource, 
								 (pathToFile, token) => cancellationTokenSource);
	
		try
		{
			await Task.Delay(TimeSpan.FromMinutes(10), cancellationTokenSource.Token)
					  .ConfigureAwait(false);
		}
		catch (TaskCanceledException tce)
		{
			// Token was cancelled, do something?
		}
			
		Foo(path);
		pathsToTokens.TryRemove(path, out cancellationTokenSource);
	}
	
	private void Foo(string path)
	{
		try
		{
			File.Delete(path);
			Debug.WriteLine("Deleted - " + DateTime.Now.ToString("h:mm:ss tt"));
		}
		catch (Exception ex)
		{
			Debug.WriteLine("EXCEPTION - " + ex.Message);
		}
	}
	
