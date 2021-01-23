    using Castle.Core.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    namespace WcfService1
    {
        public class WindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(
                    Component.For<IYourService,YourService>(),
                    Component.For<ILogger,DummyLogger>()
                    );
            }
        }
    }
