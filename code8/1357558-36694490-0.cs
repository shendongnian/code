    Dictionary<string, string> param = new Dictionary<string, string>();
	param.Add("paramA", paramA);
	param.Add("paramB", paramB);
	
	HttpClient client = new HttpClient();
	HttpFormUrlEncodedContent contents = new HttpFormUrlEncodedContent(param);
	var result = await client.PostAsync(new Uri("http://localhost:8490/api/path/tofunc")
                                                                             , contents);
	var reply = await result.Content.ReadAsStringAsync();
	if (reply.IsSuccessStatusCode)
	{ 
    }
