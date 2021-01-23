	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		// Other code...
		// Add the model generator
		services.AddTransient<ISerializer, ModelGenerator>();
	}
	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
	{
		var serializers = app.ApplicationServices.GetServices<ISerializer>();
		foreach (var serializer in serializers)
		{
			Serializers.Configure(serializer);
		}
		
		// Other code...
	}
