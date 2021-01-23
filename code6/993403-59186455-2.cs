	#region Temporary Tests
	// {{BaseUrl}}Test?api-version=1
	[HttpGet]
	[RouteVersion("Test", 1)]
	public async Task<IHttpActionResult> Test1([FromBody]GetCustomerW2GsForPropertyRequest request)
	{
		return await Task.FromResult(Ok("API Version 1 selected"));
	}
	[HttpGet]
	[RouteVersion("Test", 2)]
	[RouteVersion("Test", 3)]
	[RouteVersion("Test", 4)]
	public async Task<IHttpActionResult> Test4([FromBody]GetCustomerW2GsForPropertyRequest request)
	{
		return await Task.FromResult(Ok("API Version 2, 3 or 4 selected"));
	}
	[HttpGet]
	[RouteVersion("Test", 5, true)]
	public async Task<IHttpActionResult> Test5([FromBody]GetCustomerW2GsForPropertyRequest request)
	{
		return await Task.FromResult(Ok("API Version 5 selected"));
	}
	#endregion Temporary Tests
