	//MyController.cs
	public async Task<ActionResult> GetSomethingAsync(int id)
	{
		//lots of stuff here
		await GetAsync(id);
		return new ContentResult(result);
	}
	
	//MyService.cs
	public async Task<ProcessedResponse> GetAsync(int id)
	{
		var client = new HttpClient();
		var result = await client.GetAsync(_url+id);
		return await Process(result);
	}
