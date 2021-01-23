    public void ConfigureServices(IServiceCollection services)
    {
         var mvcCore = services.AddMvcCore();
         mvcCore.AddJsonFormatters();
         services.AddSingleton(provider => Configuration);
         services.AddSingleton<IGreeter, Greeter>();
    }
