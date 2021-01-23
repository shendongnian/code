    public void Configure(IApplicationBuilder app)
    {
        app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
        // Exception handling logging below
        app.UseExceptionHandler();
    }
