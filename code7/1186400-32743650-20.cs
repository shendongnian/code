    public void ConfigureServices(IServiceCollection services)
    {       
        services.AddMvc();
        services.Configure<MvcOptions>(options =>
        {
            //mvc options
        });
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
    }
