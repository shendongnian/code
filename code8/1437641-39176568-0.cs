    public classSqlStringLocalizerFactory
    {
        public SqlStringLocalizerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    
        public void SomeMethod()
        {
           var serviceScope = serviceProvider
             .GetRequiredService<IServiceScopeFactory>().CreateScope())
           {
               var tenant = serviceScope
                           .ServiceProvider.GetService<AppTenant>();
               // do something with tenant...
           }
        }
    }
