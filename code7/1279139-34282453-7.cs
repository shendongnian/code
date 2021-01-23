    public ServiceDecoratorWithSetting : ServiceDecorator {
        public static string Setting { get; set; }
        public ServiceDecorator(IService decoratee) : base(Setting, decoratee) { }
    }
    ServiceDecoratorWithSetting.Setting = setting;
    container.RegisterDecorator(typeof(IService), typeof(ServiceDecoratorWithSetting));
