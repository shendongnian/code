    public SqlStringLocalizerFactory(IServiceProvider serviceProvider)
    {
       _serviceProvider = serviceProvider;
    }
    public void SomeMethod()
    {
        var tenant =  _serviceProvider.GetService<AppTenant>();
    }
