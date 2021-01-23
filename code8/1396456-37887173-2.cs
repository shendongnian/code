    public class SessionInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<ISession>().UsingFactoryMethod(() => MvcApplication.CurrentSession)
                .LifeStyle
                .PerWebRequest);
        }
    }
