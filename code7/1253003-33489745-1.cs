	Result result;
	var requestJson = JsonConvert.SerializeObject(message); // Here we assume the request JSON is not too large
				
	using (var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json"))
	using (var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress) { Content = requestContent })
    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
    using (var responseStream = await response.Content.ReadAsStreamAsync())
	{
		using (var textReader = new StreamReader(responseStream))
		using (var jsonReader = new JsonTextReader(textReader))
		{
			result = JsonSerializer.CreateDefault().Deserialize<Result>(jsonReader);
		}
	}
