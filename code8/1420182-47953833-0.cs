	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		if (env.IsDevelopment()) {
            // Debug config here...
		} else {
			app.UseStatusCodePagesWithReExecute("/Error");
			app.UseExceptionHandler("/Error");
		}
        // More config...
    }
