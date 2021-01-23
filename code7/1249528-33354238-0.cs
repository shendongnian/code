	var lstWebSites = new List<string>
			{
				"https://www.stackoverflow.com",
				"https://www.google.com"
			};
	foreach (string website in lstWebSites)
	{
		var request = WebRequest.Create(website);
		request.Credentials = CredentialCache.DefaultCredentials;
		((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";   // Lie
		var response = request.GetResponse();
		if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
		{
			var stream = response.GetResponseStream();
			var reader = new StreamReader(stream);
			Console.WriteLine($"***** {website} *****");
			Console.WriteLine(reader.ReadToEnd());  // Dump HTML response
		}
	}
