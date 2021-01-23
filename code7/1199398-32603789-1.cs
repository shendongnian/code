    public void ConfigureServices(IServiceCollection services)
    {
        //some configuration
        services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
    }
