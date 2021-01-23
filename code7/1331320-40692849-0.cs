    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    ...
    //Add Middleware
    app.UseResponseCompression();
    
    ....
    }
    public void ConfigureServices(IServiceCollection services)
    {
    //Configure Compression level
    services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
    
    //Add Response compression services
    services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
    });
    }
