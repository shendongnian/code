    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    
      services.AddMediatR(typeof(Startup));
    }
