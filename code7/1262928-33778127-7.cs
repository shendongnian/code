    private static void RegisterServices(IKernel kernel)
    {
        var modules = new List<INinjectModule>
            {
                new ServiceModule()
                //, new FooModule()
                //, new BarModule()
            };
        kernel.Load(modules);
    }  
