    if (env.IsDevelopment())
    {
        app.UseBrowserLink();
        loggerFactory.AddDebug(LogLevel.Information);
        app.UseDeveloperExceptionPage();
    }
    app.UseMvc(config =>
    {
        //[...]
    });
