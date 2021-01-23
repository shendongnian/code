    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        //Other injected services. 
    }
