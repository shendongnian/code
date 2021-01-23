    using (var client = new HttpClient())
    {
    	var url = new Uri("http://localhost:9000");
    	client.DefaultRequestHeaders.Accept.Clear();
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	dynamic payLoad = new ExpandoObject();
    	    
    	DataModel model = new DataModel { Payload = payLoad };
    	    
    	//Model will be serialized automatically.
    	var response = await client.PostAsJsonAsync(url, model);
    	    
    	//It may be a good thing to make sure that your request was handled properly
    	response.EnsureSuccessStatusCode();
    	    
    	//If you need to work with the response, read its content! 
        //Here I implemented the controller so that it sends back what it received
    	//ReadAsAsync permits to deserialize the response content
    	var responseContent = await response.Content.ReadAsAsync<DataModel>();
    	    
    	// Do stuff with responseContent...
    }
