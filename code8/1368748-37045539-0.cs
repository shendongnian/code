    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IModelA, ModelA>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ViewAVM>(new ContainerControlledLifetimeManager());
        }
        protected override void ConfigureViewModelLocator()
        {
            BindViewModelToView<ViewAVM, ViewA>();
            BindViewModelToView<ViewAVM, ViewB>();
        }
        
    }
