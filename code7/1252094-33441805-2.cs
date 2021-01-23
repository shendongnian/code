    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().Configure<MvcOptions>(options =>
        {
           options.OutputFormatters.OfType<JsonOutputFormatter>()
           .First()
           .SerializerSettings
           .ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
    }
