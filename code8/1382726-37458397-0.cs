    using (var client = new HttpClient())
    {
          string url = "http://localhost:65160/test"; // <= set valid URL
          var metadata = new Metadata();
      
          client.DefaultRequestHeaders.Accept.Clear();
    	  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	  var response = await client.PostAsJsonAsync(url, metadata);
    	  response.EnsureSuccessStatusCode();
    }
