	public async Task SendRequestAsync()
	{
		var request = new SomePostRequest
		{
			Id = 20,
			Content = new byte[] { 2, 5, 7, 10 }
		};
			
		using (var stream = new MemoryStream())
		using (var bson = new BsonWriter(stream))
		{
			var jsonSerializer = new JsonSerializer();
			jsonSerializer.Serialize(bson, request);
	
			var httpRequest = new HttpRequestMessage(
					HttpMethod.Post, "http://www.yourserviceendpoint.com")
			{
				Content = new ByteArrayContent(stream.ToArray())
			}
			
			httpRequest.Content.Headers.Add("Content-Type", "application/bson");
			
			var httpClient = new HttpClient();
			var result = await httpClient.SendAsync(httpRequest);
		}
	}
