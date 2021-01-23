    public async Task ProcessRequestAsync()
    {
    	var httpClient = new HttpClient();
    	var response = await httpClient.GetAsync(
               url, 
               HttpCompletionOption.ResponseHeadersRead);
    	
    	// When we reach this, only the headers have been read.
    	// Now, you can run your method
    	FooMethod();
    	
    	// Continue reading the response. Change this to whichever
        // output type you need (string, stream, etc..)
    	var content = response.Content.ReadAsStringAsync();
    }
