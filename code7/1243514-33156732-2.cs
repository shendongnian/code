        var container = new UnityContainer();
        container.RegisterType<IMessagingClient, ServiceBusMessagingClient>("One");
  
        container.RegisterType<IMessagingClient, FailoverMessagingClient>("Two", 
            new InjectionConstructor(new ResolvedParameter<IMessagingClient>("One"), new ResolvedParameter<IMessagingClient>("One")));
        var failOverMessagingClient = container.Resolve<IMessagingClient>("Two");
