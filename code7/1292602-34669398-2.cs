    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
        ILoggerFactory loggerFactory)
    {
        app.Map("/app", staticFiles =>
		{
			staticFiles.Use((context, func) =>
			{
				if (!context.User.Identity.IsAuthenticated)
				{
					context.Response.StatusCode = 403;
				} 
                else 
                {
                    app.UseStaticFiles();
                }		
				return func();
		    });
		});
    }
