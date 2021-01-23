        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // other app setup omitted.
            if (env.IsDevelopment())
            {
                // development settings here.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // production settings here.
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                                 .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<YourDbContext>()
                                    .Database.Migrate();
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }
