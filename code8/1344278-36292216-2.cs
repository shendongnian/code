    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureServicesImpl(services).Wait(); //bridge
    }
    
    public async Task ConfigureServicesImpl(IServiceCollection services)
    {
       await ...;
    }
