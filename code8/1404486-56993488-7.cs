    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
    }
