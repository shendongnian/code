    public void Configure(IApplicationBuilder app)
    {
        // use inline middleware
        app.Use(async (context, next) =>
        {
            // if specific condition does not meet
            if (context.Request.Path.ToString().Equals("/foo"))
            {
                context.Response.Redirect("path/to/controller/action");
            }
            else
            {
                await next.Invoke();
            }
        });
        // or use a middleware class
        app.UseMiddleware<RedirectMiddleware>();
        app.UseMvc();
    }
