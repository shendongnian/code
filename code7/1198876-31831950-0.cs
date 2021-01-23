	private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
	public async Task<T> GetAsync(
				string key, Func<Task<T>> populator, TimeSpan expire, object parameters)
	{
		if (parameters != null)
			key += JsonConvert.SerializeObject(parameters);
	
		if (!_cache.Contains(key))
		{
			await semaphoreSlim.WaitAsync();
			try
			{
				var data = await populator();
				if (!_cache.Contains(key))
					_cache.Add(key, data, DateTimeOffset.Now.Add(expire));
			}
			finally
			{
				semaphoreSlim.Release();
			}
		}
	
		return (T)_cache.Get(key);
	}
