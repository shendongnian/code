    private IHostingEnvironment _env;
    
    public Startup(IHostingEnvironment env)
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
        services.AddTransient<ISomeService, FakeSomeService>();
      }
      else
      {
        // production stuff
        services.AddTransient<ISomeService, SomeService>();
      }
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
         if (env.IsDevelopment())
         {
             app.UseFakeAuthentication();
         }
         else
         {
             app.UseRealAuthentication();
         }
    }
