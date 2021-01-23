    container.RegisterDecorator(typeof(IService), typeof(ServiceDecorator));
    container.RegisterInitializer<ServiceDecorator>(dec => dec.Setting = setting);
    public ServiceDecorator : IService {
        public string Setting { get; set; }
        public ServiceDecorator(IService decoratee) { }
    }
