    protected void Application_Start()
    {
      var builder = new ContainerBuilder();
    
      // Register your service implementations.
      builder.RegisterType<TestService.Service1>();
    
      // Set the dependency resolver.
      var container = builder.Build();
      AutofacHostFactory.Container = container;
    }
