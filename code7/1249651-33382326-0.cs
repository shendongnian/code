    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:9000/");
        
        // code removed
    
        HttpResponseMessage response = await client.GetAsync("api/products/1");
        if (response.IsSuccessStatusCode)
        {
            // do something
        }
    }
