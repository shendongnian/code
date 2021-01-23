	using (var client = new HttpClient())
	{
		var response = client.GetAsync(uri).Result;
		
		var contentType = response.Content.Headers.ContentType;
	}
