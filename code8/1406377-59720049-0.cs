    services.AddMvc()
	.AddJsonOptions(o =>
	{
		if (o.SerializerSettings.ContractResolver != null)
		{
			var castedResolver = o.SerializerSettings.ContractResolver
			as DefaultContractResolver;
			castedResolver.NamingStrategy = null;
		}
	});
