    static void Main(string[] args)
    {
        var kernel = new StandardKernel();
        var ds = new List<int> { 1, 2 };
        kernel
            .Bind<ILoader>()
            .To<TestLoader>()
            .InSingletonScope()
            .WithConstructorArgument("enumerable", ds);
        var tc1 = kernel.Get<TestClass>();
        var tc2 = kernel.Get<TestClass>();
        tc1.Init();
        tc2.Init();
        Console.ReadLine();
    }
