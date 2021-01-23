    public async Task<string> GetPageAsync(string url)
    {
    	var httpClient = new HttpClient();
    	var response = await httpClient.GetAsync(url);
    	return response.Content.ReadAsStringAsync();
    }
