    public async Task<string> DownloadWebContentAsync(string url)
    {
    	var client = new HttpClient();
    	// Assuming a GET request
    	var response = await client.GetAsStringAsync(url);
    	
    	// Do some string processing..
        return response;
    }
