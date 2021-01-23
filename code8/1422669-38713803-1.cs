    private IHostingEnvironment _env;
    
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
      _env = env;
      // other stuff
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
      // ...
      if (_env.IsDevelopment())
      {
        // dev stuff
         services.AddSingleton<IAuthorizationHandler, FakeAuthorizationHandler>();
      }
      else
      {
        // production stuff
        services.AddSingleton<IAuthorizationHandler, RealAuthorizationHandler>();
      }
    }
