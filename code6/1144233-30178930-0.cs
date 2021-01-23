    private HttpClient GetHttpClient()
    {
    	// Initialize client with default headers, base address, etc.
    	var httpClient = new HttpClient();
    	httpClient.BaseAddress = new Uri("https://sample.com");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	// Set some other headers in necessary...
    	
    	return httpClient;
    }
    
    private async Task DeleteUser(string token)
    {
    	using (var httpClient = GetHttpClient())
    		await httpClient.DeleteAsync("api/users/delete?token=" + token);
    }
