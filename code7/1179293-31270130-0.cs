    public void ConfigureServices(IServiceCollection services)
    {
       services.AddMvc();
       services.ConfigureMvc(options =>
       {
          options.Filters.Add(new YouGlobalActionFilter());
       }
    }
