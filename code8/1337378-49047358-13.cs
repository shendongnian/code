    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler(ERROR_URL);
        }
         app.UseStaticFiles();
         app.UseAuthentication();
         app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: DEFAULT_ROUTING);
        });
    }
