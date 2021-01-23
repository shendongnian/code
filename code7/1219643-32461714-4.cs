    public void Configure(IApplicationBuilder app)
    {
        var serviceProvider = app.ApplicationServices;
    	var hostingEnv = serviceProvider.GetService<IHostingEnvironment>();
    }
