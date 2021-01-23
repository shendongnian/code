    public void ConfigureServices(IServiceCollection services) {
        services.AddAuthentication(options => {
            // This value must correspond to the instance of the cookie
            // middleware used to create the authentication cookie.
            options.SignInScheme = "MyCookieMiddlewareInstance";
        });
    }
