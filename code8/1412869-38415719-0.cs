    public void ConfigureServices(IServiceCollection services)
    {
        ...    
        // Add framework services.
        services.AddMvc(config =>
        {
            // Add XML Content Negotiation
            config.RespectBrowserAcceptHeader = true;
            config.InputFormatters.Clear();
            config.InputFormatters.Add(new JsonInputFormatter());
        });
        ...
    }
