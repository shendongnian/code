	static readonly Lazy<Task<int>> MySharedAsyncInteger = new Lazy<Task<int>>(
	async () =>
	{
		int i = 0;
		while (i < 5)
		{
			Thread.Sleep(500);
			i++;
		}
			
		await Task.Delay(TimeSpan.FromSeconds(2));
		return 0;
	});
	
