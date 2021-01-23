    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // ...
            if (env.IsDevelopment())
            {
                // ...
                app.UseDirectoryBrowser();
                var provider = new FileExtensionContentTypeProvider();
                // Add .scss mapping
                provider.Mappings[".scss"] = "text/css";
                app.UseStaticFiles(new StaticFileOptions()
                {
                    ContentTypeProvider = provider
                });
            }
            else
            {
                // ...
                app.UseStaticFiles();
            }
            // ...
        }
