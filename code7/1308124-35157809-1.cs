	public T Deserialize<T>(string content)
	{
		var settings = new JsonSerializerSettings
		{ 
			NullValueHandling = NullValueHandling.Ignore    
		};
		
		try
		{
			return JsonConvert.DeserializeObject<T>(content, settings);
		}
		catch (IOException e) 
        {
			throw new ApiException(HttpStatusCode.InternalServerError, e.Message);
		}
	}
