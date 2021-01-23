	public void ConfigureServices(IServiceCollection services)
	{
		// Other code...
		// Add the global filter for the serializer
		services.AddMvc(options =>
		{
			options.Filters.Add(new SerializerFilter());
		});
		// Other code...
	}
