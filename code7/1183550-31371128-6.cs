    // Create the factory. The factory will have a static method that the DI system can register a lambda with, so that the factory can resolve through the DI container without being tightly coupled to it.
    public class BarFactory
    {
        private static Func<IBarDependency> internalFactory;
        public static void SetFactory(Func<IBarDependency> factory)
        {
            this.internalFactory = factory;
        }
        public IBarDependency CreateBar()
        {
            // Use the DI container lambda assigned in SetFactory to resolve the dependency.
            return internalFactory();
        }
    }
    public class DependencyInjectionBootstrap
    {
        IContainer container;
        public void SetupDI()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BarDependency>().As<IBarDependency>();
            container = builder.Build();
            // Tell the factory to resolve all IBarDependencies through our IContainer.
            BarFactory.SetFactory(() => container.Resolve<IBarDependency>());
        }
    }
    public class FooViewModel
    {
        public void ExecuteSave()
        {
            var barFactory = new BarFactory();
            IBarDependency bar = barFactory.CreateBar();
        }
    }
