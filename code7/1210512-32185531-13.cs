	public async Task SendRequestAsync()
	{	
		using (var stream = new MemoryStream())
		using (var bson = new BsonWriter(stream))
		{
			var jsonSerializer = new JsonSerializer();
			var request = new SomePostRequest
			{
				Id = 20,
				Content = new byte[] { 2, 5, 7, 10 }
			};
			jsonSerializer.Serialize(bson, request);
	
			var client = new HttpClient
			{
				BaseAddress = new Uri("http://www.yourservicelocation.com")
			};
			
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/bson"));
	
			var byteArrayContent = new ByteArrayContent(stream.ToArray());
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/bson");
			var result = await client.PostAsync(
					"api/SomeData/Incoming", byteArrayContent);
					
			result.EnsureSuccessStatusCode();
		}
	}
