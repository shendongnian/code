    static void Main(string[] args)
    { 
         var container = new Container();
         Bootstrap.Start(container);
         _testInjectedClass = container.GetInstance<TestInjectedClass>();
         _testInjectedClass.UserRepoRun();
         Console.ReadLine();
    }
    class Bootstrap
    {
        public static void Start(Container container)
        {
            // Register your types, for instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
            container.Register<ITestInjectedClass, TestInjectedClass>(Lifestyle.Singleton);
            container.Register<TestInjectedClass>();
            // Optionally verify the container.
            container.Verify();
        }
    }
