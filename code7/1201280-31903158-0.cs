    class Bootstrap
    {
        public static Container container;
        public static void Start()
        {
            container = new Container();
            // Register your types, for instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
            container.Register<ITestInjectedClass, TestInjectedClass>(Lifestyle.Singleton);
            //container.Register<IUserRepository, TestInjectedClass>(Lifestyle.Singleton);
            //container.Register<IUserContext, WinFormsUserContext>();
            container.Register<TestInjectedClass>();
            // Optionally verify the container.
            container.Verify();
        }
    }
