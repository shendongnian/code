    public async Task<string> UploadGameToWebsiteAsync(string filename, string url, string method = null)
    {
    	using (var client = new HttpClient())
    	{
    		using (var fileStream = new StreamContent(System.IO.File.Open(filename, FileMode.Open, FileAccess.Read)))
    		{
    			var content = new MultipartFormDataContent();
    			content.Add(fileStream, "Game", "Game.txt");
    			HttpResponseMessage result = await client.PutAsync(url, content).ConfigureAwait(true);
    			return result.ToString();
    		}
        }
    }
