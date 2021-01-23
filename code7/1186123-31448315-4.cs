	public Response UploadXmlData(string destinationUrl, string requestXml,Request req)
	{
		Response resp=new Response();
		System.Uri uri = new System.Uri(destinationUrl);
		using (WebClient client = new WebClient())
		{
			var response = client.UploadString(uri, "POST", requestXml, req);
			using (var responseStream = new MemoryStream(Encoding.UTF8.GetBytes(response))
			{
				return Utilities.ParseWithoutSoapEnv(responseStream);
			}
		}
	}
