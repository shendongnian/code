	[HttpGet]
	public IHttpActionResult Get(string country)
	{
		var result = repo.GetCategories(new List<string> { country});
		return Ok(result);
	}
	
