	public readonly SemaphoreSlim = new SemaphoreSlim(5, 5);
	public readonly HttpClient httpClient = new HttpClient();
	public async Task<string> LimitedQueryAsync(string url)
	{
		await semaphoreSlim.WaitAsync();
		try
		{
			var response = await httpClient.GetAsync(url);
			return response.Content.ReadAsStringAsync();
		}
		finally
		{
			semaphoreSlim.Release();
		}
	}
	
