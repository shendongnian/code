    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .Pick().WithServiceDefaultInterfaces()
                .LifestyleTransient()
                );
        }
    }  
