    public void Configure(IApplicationBuilder app)
    {
        app.UseStatusCodePagesWithReExecute("/Errors/{0}");
        // Exception handling logging below
        app.UseElmCapture();
        app.UseElmPage();
    }
