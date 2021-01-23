    public static HttpConfiguration Register()
    {
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        
        config.Filters.Add(new HostAuthenticationAttribute("bearer")); //added this
        config.Filters.Add(new AuthorizeAttribute());
        config.EnableCors(new EnableCorsAttribute("*", "*", "*", "*"));
        return config;
    }
