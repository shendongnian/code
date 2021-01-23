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
                // Prism 6.0 uses RegisterTypeForNavigation from the Prism.Unity namespace
                this.container.RegisterTypeForNavigation<SecondView>("SecondView");
            }
        }
    }
