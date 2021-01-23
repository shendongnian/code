	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.Add(new BsonMediaTypeFormatter());
		}
	}
	
