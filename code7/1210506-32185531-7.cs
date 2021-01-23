	public async Task SendRequestAsync()
	{	
		using (var stream = new MemoryStream())
		using (var bson = new BsonWriter(stream))
		{
			var jsonSerializer = new JsonSerializer();
			jsonSerializer.Serialize(bson, request);
	
			var client = new HttpClient
			{
				BaseAddress = new Uri("http://www.yourservicelocation.com")
			};
			
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/bson"));
					
			var request = new SomePostRequest
			{
				Id = 20,
				Content = new byte[] { 2, 5, 7, 10 }
			};
	
			var result = await client.PostAsync(
					"api/SomeData/Incoming", new ByteArrayContent(stream.ToArray());
					
			result.EnsureSuccessStatusCode();
		}
	}
