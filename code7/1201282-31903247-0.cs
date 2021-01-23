    static void Main(string[] args)
    { 
         var container = new Container();
         Bootstrap.Start(container);
         _testInjectedClass= new TestInjectedClass(container.GetInstance<IUserRepository>());
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
            //container.Register<IUserRepository, TestInjectedClass>(Lifestyle.Singleton);
            //container.Register<IUserContext, WinFormsUserContext>();
            container.Register<TestInjectedClass>();
            // Optionally verify the container.
            container.Verify();
        }
    }
