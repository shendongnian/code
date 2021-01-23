    public static void Register(HttpConfiguration config)
    {
        var corsAttr = new EnableCorsAttribute("http://example.com", "*", "*");
        config.EnableCors(corsAttr);
    }
