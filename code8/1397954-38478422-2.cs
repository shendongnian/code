    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<KestrelAuthenticationMiddleware>();
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = Configuration[AppConstants.Authority],
                RequireHttpsMetadata = false,
                AutomaticChallenge = true,
                ScopeName = Configuration[AppConstants.ScopeName],
                ScopeSecret = Configuration[AppConstants.ScopeSecret],
                AutomaticAuthenticate = true
            });
            app.UseMvc();
        }
