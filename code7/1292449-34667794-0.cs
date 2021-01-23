    using (var client = new HttpClient())
    {
    	//Api Base address
        client.BaseAddress = new Uri("http://localhost:9000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        //Sending a GET request to endpoint api/products/1
        HttpResponseMessage response = await client.GetAsync("api/person/1");
        if (response.IsSuccessStatusCode)
        {
    		//Getting the result and mapping to a Product object
            Person person = await response.Content.ReadAsAsync<Person>();
        }
    }
