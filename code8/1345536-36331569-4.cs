	using (var client = new HttpClient())
	{
		var response = await client.GetAsync(url);
		var responseStream = await client.ReadAsStreamAsync();
		using (var fixedEncodingReader = new StreamReader(responseStream, Encoding.GetEncoding(1255)))
		{
			string responseString = fixedEncodingReader.ReadToEnd();
		}
	}
