	public RES Post<RES>(string url, string content) where RES : new()
	{
		using (var client = new WebClient())
		{
			client.Headers[HttpRequestHeader.ContentType] = "application/json";
			var result = client.UploadString(url, content);
			return JsonConvert.DeserializeObject<RES>(result, jsonSerializerSettings);
		}
	}
