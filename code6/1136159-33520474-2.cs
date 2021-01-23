    public void Configure(IApplicationBuilder app)
            {
                app.Use(async (ctx, next) =>
                {
                    var hostingEnvironment = app.ApplicationServices.GetService<IHostingEnvironment>();
                    var realPath = hostingEnvironment.WebRootPath + ctx.Request.Path.Value;
     
    				// do something with the file
                    
                    await next();
                });
     
            }
