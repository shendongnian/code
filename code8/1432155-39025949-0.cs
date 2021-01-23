    // new signature (I changed the name and prefixed Async which is a common convention)
	internal static async Task<string> ExtractFileAsync(HttpRequestMessage request)
	{
		if (request.Content.IsMimeMultipartContent())
		{
			string uploadRoot = ServiceHelper.GetUploadDirectoryPath();
			var provider = new MultipartFormDataStreamProvider(uploadRoot);
			await request.Content.ReadAsMultipartAsync(provider);
			/* rest of code */
		}
	}
    // calling method example from some Web API Controller
	public async Task<IHttpActionResult> Post(CancellationToken token)
	{ 
		var result = await ExtractFileAsync(Request).ConfigureAwait(true); 
		/*some other code*/
	}
