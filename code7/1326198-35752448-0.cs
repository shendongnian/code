	public async Task<TestHttpResponseMessage> Post(string url, string jsonPayload = "", Dictionary<string, string> headers = null, IFilter filter = null, HttpContent content = null)
	{
		using (var server = CreateTestserver(filter))
		{
			if (!url.StartsWith("http"))
				url = "http://localhost/" + url;
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(url),
				Method = HttpMethod.Post,
				Content = content ?? new StringContent(jsonPayload, Encoding.UTF8, "application/json")
			};
			request.Headers.Add("usertoken", OpenApiApplication.TestApiKey.ToString());
			if (headers == null)
				headers = new Dictionary<string, string>();
			foreach (var header in headers)
				request.Content.Headers.Add(header.Key, header.Value);
			var httpResponseMessage = await server.HttpClient.SendAsync(request);
			var stringResult = await httpResponseMessage.Content.ReadAsStringAsync();
			return new TestHttpResponseMessage { JsonObject = Json.Decode(stringResult), HttpResponseMessage = httpResponseMessage };
		}
	}
