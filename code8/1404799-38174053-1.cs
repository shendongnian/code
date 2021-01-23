    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddLocalization(options => options.ResourcesPath = "Resources")
            .AddMvc(options => { options.Filters.Add(new CultureToUrlActionFilter()); })
            .AddViewLocalization()
            .AddDataAnnotationsLocalization();
    }
