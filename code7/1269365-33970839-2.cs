	public async Task<string> ReturnDataFromUrlAsync(
									List<List<KeyValuePair<string, string>>> listOfPostData)
	{
		var client = new HttpClient
		{
			BaseAddress = new Uri("http://localhost:23081")
		};
	
		var downloadTasks = listOfPostData.Select(postData =>
		{
			var content = new FormUrlEncodedContent(postData);
			return client.PostAsync("/Token", content);
		});
		
		HttpResponseMessage[] response = await Task.WhenAll(downloadTasks);
	
		var tokenBuilder = new StringBuilder(response.Length);
		foreach (var element in response.Where(message => message.IsSuccessStatusCode))
		{
			tokenBuilder.Append(await element.Content.ReadAsStringAsync());
		}
		return tokenBuilder.ToString();
	}
	
