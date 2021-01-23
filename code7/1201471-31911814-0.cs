    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestyleTransient());
        }
    }
