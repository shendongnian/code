    protected async T Get<T>(string uri)
    {
    	var client = GetNewClient();
    	var response = await client.GetAsync(uri);
        // I'm guessing ReadAsAsync<T> is a helper method, can't find it myself
    	return await response.Content.ReadAsAsync<T>();
    }
