    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>(). //MVC
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IHttpController>(). //Web API
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());
        }
    }
