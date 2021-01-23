    namespace Module.MyModule
    {
        [Module(ModuleName="MyModule", OnDemand=false)]
        public class MyModule : IModule
        {
            private readonly IUnityContainer container;
            public MyModule(IUnityContainer container, IMigrationTaskRegistrationService taskRegistration)
            {
                if (container == null)
                    throw new ArgumentNullException("container");
                this.container = container;
            }
            public void Initialize()
            {
                this.container.RegisterType<Object, SecondView>("SecondView");
            }
        }
    }
