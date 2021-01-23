	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		using (var serviceScope = app.ApplicationServices.CreateScope())
		{
			var services = serviceScope.ServiceProvider;
			var myDbContext = services.GetService<MyDbContext>();
		}
	}
