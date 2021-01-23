    public void ConfigureServices(IServiceCollection services)
    {
        var corsBuilder = new CorsPolicyBuilder();
        corsBuilder.AllowAnyHeader();
        corsBuilder.AllowAnyMethod();
        corsBuilder.AllowAnyOrigin();
        corsBuilder.AllowCredentials();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", corsBuilder.Build());
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseCors("AllowAll");
    }
