	// GET api/systeminfo/allowedapi
	[HttpGet]
	[Route("allowedapi")]
	[ResponseType(typeof (WebApiCollectionDto))]
	public async Task<IHttpActionResult> GetAllowedApi()
	{
		List<string> apiList = new List<string>();
		IApiExplorer apiExplorer = Configuration.Services.GetApiExplorer();
		foreach (ApiDescription apiDescription in apiExplorer.ApiDescriptions)
			apiList.Add(apiDescription.RelativePath);
		WebApiCollectionDto result = new WebApiCollectionDto(apiList);
		return await Task.FromResult(Ok(result));
	}
