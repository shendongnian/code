	string url = "https://localhost:8080/confluence/rest/api/content/123456/child/attachment";
	string filename = @"C:\temp\test.txt";
	using (var client = new WebClient())
	{
		string authorizationString = username + ":" + password;
		string encodedValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(authorizationString));
		client.Headers.Add("Authorization", "Basic " + encodedValue);
		client.Headers.Add("X-Atlassian-Token", "nocheck");
		byte[] result = client.UploadFile(url, filename);
		string responseAsString = Encoding.Default.GetString(result);
	}
