    public void Configure(IApplicationEnvironment appEnv, IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error/500");
            app.UseStatusCodePagesWithReExecute("/error/{0}");
        }
        app.UseStaticFiles();
        app.UseMvc(routes => MapRoutes(routes, appEnv));
    }
