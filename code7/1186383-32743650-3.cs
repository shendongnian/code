    public void Configure(IApplicationBuilder app)
        {
            // Add .Value to get the token string
            var token = Configuration.GetSection("AppSettings:token");
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is a token with key (" + token.Key + ") " + token.Value);
            });
        }
