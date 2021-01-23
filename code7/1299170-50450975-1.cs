    public void Configure(IApplicationBuilder app)
    {
        ...
        app.Map("/api", HandleWebApiRequests);
        ...
    }
    private static void HandleWebApiRequests(IApplicationBuilder app)
    {
        app.UseWebApi(config);
    }
