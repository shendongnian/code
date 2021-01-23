	public async Task InitializeAsync()
	{
		LoadFromLocal();
		await AttemptDatabaseLoadAsync();
	}
	public async Task AttemptDatabaseLoadAsyncAsync()
	{
		while(ConnectionAttempts < MAX_CONNECTION_ATTEMPTS)
		{
			Task<bool> Attempt = TryLoad ();
			bool success = await Attempt;
			if (success)
			{
				//call func to load data into program memory proper
			}
			else
			{
				ConnectionAttempts++;
			}
		}
	}
	
