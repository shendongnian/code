    static void Main(string[] args) {
        _container = new WindsorContainer();
        _container.AddFacility<WcfFacility>();
        _container.Register(Component.For<IHelloService>()
                                     .ImplementedBy<HelloService>()
                                     .AsWcfService(new DefaultServiceModel().OnCreated(OnCreated)));
    }
    private static void OnCreated(ServiceHost serviceHost)
    {
        var serviceBehavior = (ServiceBehaviorAttribute) serviceHost.Description.Behaviors.Single(_ => _ is ServiceBehaviorAttribute);
        serviceBehavior.ConcurrencyMode = ConcurrencyMode.Multiple;
        serviceBehavior.InstanceContextMode = InstanceContextMode.PerSession;
    }
