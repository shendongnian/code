    services.AddAuthentication(options =>...)
                .AddOpenIdConnect(options =>...)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/path/unauthorized";
    
                })
