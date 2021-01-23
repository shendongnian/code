	public async Task<HttpResponseMessage> SendAsync(string uri, string value)
	{
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri(URI);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
							new MediaTypeWithQualityHeaderValue("application/json"));
	
			return await client.PostAsJsonAsync(uri, content);
		}
	}
