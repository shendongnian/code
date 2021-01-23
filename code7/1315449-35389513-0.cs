	[HttpGet]
	public async Task<IHttpActionResult> GetAllRecordsAsync()
	{
	   var result = await FrameworkApi.GetRecordsAsync();
	   return Ok(result);
	}
	
	public Task<List<Record>> GetRecordsAsync()
	{
		return FrameworkDbApi.GetRecordsAsync();
	}
	
	public async Task<List<Record>> GetRecordsAsync()
	{
		var result = await NoSqlDocumentClient.GetDefaultDatabase();
		return result.GetCollection<Record>("record").AsQueryable().ToList();          
	}
	
	
	
