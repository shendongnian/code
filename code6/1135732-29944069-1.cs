    public class HelloBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;
        public HelloBootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<ShellViewModel>();
            container.PerRequest<ModernWindowViewModel>();
        }
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {
            Assembly.GetExecutingAssembly()
        };
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            return container.GetInstance(serviceType, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ModernWindowViewModel>();
        }
    }
