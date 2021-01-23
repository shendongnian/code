    public class ApplicationBootstrapper
    {
        private IContainer _container;
        public ApplicationBootstrapper() {
            _container = new SomeDIContainer();
            
            _container.Register<SomeComponent>().AsSingleton(); // Singleton instance, same instance for every resolve
            _container.Register<SomeOtherComponent>().AsTransient(); // New instance per resolve
            // ... more registration code for all your components
            // most containers have a convention based registration
            // system e.g. _container.Register().Classes().BasedOn<ViewModelBase> etc
            
            var appRoot = _container.Resolve<MainWindowViewModel>();
            appRoot.ShowWindow();
        }
    }
