    public void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            // if specific condition does not meet
            if (!context.Request.Path.ToString().Equals("/foo"))
            {
                // then redirect
                context.Response.Redirect("/controller/action");
            }
        });
        app.UseMvc();
    }
