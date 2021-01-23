	public async Task ProcessAsync()
	{
		var client = new ServiceClient();
		string result = await client.ProcessAsync(stream);
	}
	
