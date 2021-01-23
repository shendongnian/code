    container.RegisterType<IConfigurationContext>(
        //Instance per http request (unit of work)
        new PerRequestLifetimeManager(),
        //Create using factory
        new InjectionFactory(c => c.Resolve<IConfigurationContextFactory>.CreateContext()));
