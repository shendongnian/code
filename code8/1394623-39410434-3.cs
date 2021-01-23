    public void ConfigureServices(IServiceCollection services)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();
    
            var serializer = JsonSerializer.Create(settings);
    
            services.Add(new ServiceDescriptor(typeof(JsonSerializer), 
                                               provider => serializer,
                                               ServiceLifetime.Transient));
    
            // register other services like SignalR, MVC and custom services
         }
