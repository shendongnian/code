    public async Task<string> UploadGameToWebsiteAsync(string filename, string url, string method = null)
    {
    	HttpClient client = null;
    	StreamContent fileStream = null;
    	try
    	{
    		client = new HttpClient();
    		fileStream = new StreamContent(System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
    		var content = new MultipartFormDataContent();
    		content.Add(fileStream, "Game", "Game.txt");
    		HttpResponseMessage result = await client.PutAsync(url, content).ConfigureAwait(true);
    		return result.ToString();
    	}
    	finally 
    	{
    		// c# 6 syntax
    		client?.Dispose();
    		fileStream?.Dispose(); // StreamContent also disposes the underlying file stream
    	}
    }
