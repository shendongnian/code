	public async Task<Response> UploadXmlDataAsync(
					 string destinationUrl, 
					 string requestXml,
					 Request req)
	{
		try
		{
			Response resp=new Response();
			System.Uri uri = new System.Uri(destinationUrl);
			
			var httpClient = new HttpClient();
			var response = await httpClient.PostAsync(Uri, new StringContent(requestxml))
								   .ConfigureAwait(false);
			var responeStream = response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			
			return Utilities.ParseWithoutSoapEnv(responseStream);
		}
	}
	
