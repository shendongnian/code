            public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            ...
            app.UseMicrosoftAccountAuthentication(options =>
            {
                options.ClientId = Configuration["AppSettings:AzureClientId"];
                options.ClientSecret = Configuration["AppSettings:AzureClientSecret"];
                options.AuthenticationScheme = "Microsoft";
                options.SignInScheme = "Cookies";
                options.CallbackPath = new PathString("/signin-microsoft");
                options.AuthorizationEndpoint = MicrosoftAccountDefaults.AuthorizationEndpoint;
                options.TokenEndpoint = MicrosoftAccountDefaults.TokenEndpoint;
            });
        }
