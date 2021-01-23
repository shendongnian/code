    public async Task<HttpResponseMessage> Image(int id)
	{ 
		string filepath = @"e:\testing\file";
		if (Request.Content.IsMimeMultipartContent())
		{
			var streamProvider = new MultipartFormDataStreamProvider(filepath);
			await Request.Content.ReadAsMultipartAsync(streamProvider);
			foreach (MultipartFileData fileData in streamProvider.FileData)
			{
				if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
			{
				return Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
			}
			string fileName = fileData.Headers.ContentDisposition.FileName;
			if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
			{
				fileName = fileName.Trim('"');
			}
			if (fileName.Contains(@"/") || fileName.Contains(@"\"))
			{
				fileName = Path.GetFileName(fileName);
			}
			File.Move(fileData.LocalFileName, Path.Combine(filepath, fileName));
		}
		return Request.CreateResponse(HttpStatusCode.OK);
	}
