           public void Configure(IApplicationBuilder app, 
			IApplicationEnvironment applicationEnvironment)
        {
            app.UseIISPlatformHandler();
			
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(applicationEnvironment.ApplicationVersion);
            });
        }
