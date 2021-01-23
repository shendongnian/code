    public class SettingsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
             container.Register(Component.For<MySettings>().LifestyleSingleton());
        }
    }
