    container.RegisterSingleton<MySetting>(new MySetting(setting));
    container.RegisterDecorator(typeof(IService), typeof(ServiceDecorator));
    public ServiceDecorator : IService {
        public ServiceDecorator(MySetting setting, IService decoratee) { }
    }
