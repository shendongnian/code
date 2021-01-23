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
		}).ToList();
	
		var tokenBuilder = new StringBuilder(downloadTasks.Count);
		while (downloadTasks.Count > 0)
		{
			var finishedTask = await Task.WhenAny(downloadTasks);
			downloadTasks.Remove(finishedTask);
			var response = await finishedTask;
			
			if (!response.IsSuccessStatusCode)
				continue;
				
			var token = await response.Content.ReadAsStringAsync();
			tokenBuilder.Append(token);
		}
		
		return tokenBuilder.ToString();
	}
