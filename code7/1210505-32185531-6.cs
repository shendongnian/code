	public async Task SendRequestAsync()
	{
		var client = new HttpClient
		{
			BaseAddress = new Uri("http://www.yourserviceaddress.com");
		};
	
		// Set the Accept header for BSON.
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/bson"));
	
		var request = new SomePostRequest
		{
			Id = 20,
			Content = new byte[] { 2, 5, 7, 10 }
		};
	
		// POST using the BSON formatter.
		MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
		var result = await client.PostAsync("api/SomeData/Incoming", request, bsonFormatter);
		
		result.EnsureSuccessStatusCode();
	}
	
