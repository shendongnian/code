    public void Configure(IApplicationBuilder app)
    {
        // app.UseErrorPage(ErrorPageOptions.ShowAll);
        // app.UseStatusCodePages();
        // app.UseStatusCodePages(context => context.HttpContext.Response.SendAsync("Handler, status code: " + context.HttpContext.Response.StatusCode, "text/plain"));
        // app.UseStatusCodePages("text/plain", "Response, status code: {0}");
        // app.UseStatusCodePagesWithRedirects("~/errors/{0}");
        // app.UseStatusCodePagesWithRedirects("/base/errors/{0}");
        // app.UseStatusCodePages(builder => builder.UseWelcomePage());
        app.UseStatusCodePagesWithReExecute("/Errors/{0}");  // I use this version
    
        // Exception handling logging below
        app.UseExceptionHandler();
    }
