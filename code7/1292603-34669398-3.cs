    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
        ILoggerFactory loggerFactory)
    {
        app.UseStaticFiles(new StaticFileOptions()
        {
	        OnPrepareResponse = s =>
	        {
		        if (s.Context.Request.Path.StartsWithSegments(new PathString("/app")) && 
		           !s.Context.User.Identity.IsAuthenticated)
		        {
			        s.Context.Response.StatusCode = 403;
			        s.Context.Response.WriteAsync("You are not authorized.");
		        }
	        }
        });
    }
