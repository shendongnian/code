    var serviceA = container.Resolve<IServiceA>();
    System.Console.WriteLine(serviceA.Test);
    
    var serviceB = container.Resolve<IServiceB>();
    System.Console.WriteLine(serviceB.Test);
