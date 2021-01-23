    static void Main(string[] args)
    { 
        Bootstrap.Start();
        _testInjectedClass = Bootstrap.container.GetInstance<ITestInjectedClass>();
        _testInjectedClass.UserRepoRun();
        Console.ReadLine();
    }
