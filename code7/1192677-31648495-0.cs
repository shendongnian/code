	[HttpGet]
	public async Task<HttpResponseMessage> GetAsync()
	{
		Client someClient = new Client();
		var aTask = someClient.AAsync();
		var bTask = someClient.BAsync();
		await Task.WhenAll(aTask, bTask);
		var response = { a = aTask.Result, b = bTask.Result };
		return Response.Create(OK, response}
	}
	
