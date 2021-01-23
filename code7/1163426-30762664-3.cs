    public void Configure(IApplicationBuilder app)
    {
        ...
        
        var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
        UrlHelperExtensions.Configure(httpContextAccessor);
    
        ...
    }
