    public class UserServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserService1>()
                .ImplementedBy<UserService1>()
                .LifestyleTransient());
            container.Register(Component.For<IUserService2>()
                .ImplementedBy<UserService2>()
                .LifestyleTransient());
        }
    }
