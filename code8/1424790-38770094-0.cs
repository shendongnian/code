    using (HttpClient client = new HttpClient())
    {
    	using (HttpResponseMessage response = await client.GetAsync(page))
        {
    	    using (HttpContent content = response.Content)
    	    {
    	        string contentString = await content.ReadAsStringAsync();
    
    	    }
    
        }
    }
