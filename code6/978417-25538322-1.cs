	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//... 
			var odataFormatters = System.Web.OData.Formatter.ODataMediaTypeFormatters.Create(
				System.Web.OData.Formatter.Serialization.DefaultODataSerializerProvider.Instance, 
				System.Web.OData.Formatter.Deserialization.DefaultODataDeserializerProvider.Instance);
			config.Formatters.AddRange(odataFormatters);
