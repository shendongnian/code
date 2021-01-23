	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//... 
			var odataFormatters = System.Web.OData.Formatter.ODataMediaTypeFormatters.Create(
				new System.Web.OData.Formatter.Serialization.DefaultODataSerializerProvider(), 
				new System.Web.OData.Formatter.Deserialization.DefaultODataDeserializerProvider());
			config.Formatters.AddRange(odataFormatters);
