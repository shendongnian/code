	[HttpPost]
	public async Task<JsonResult> UploadFiles()
	{
		byte[] bytes = await Request.Content.ReadAsByteArrayAsync();
	}
	
