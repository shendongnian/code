	public async Task<ActionResult> Index()
	{
		var response1 = client.GetAsync("webapi/WebApiController1/Method1");
		var response2 = client.GetAsync("webapi/WebApiController2/Method2");
		var response3 = client.GetAsync("webapi/WebApiController3/Method3");
		var response4 = client.GetAsync("webapi/WebApiController4/Method4");
		
		await Task.WhenAll(response1, response2, response3, response4);
		// You will reach this line once all requests finish execution.
	}
