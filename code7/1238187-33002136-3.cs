    AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) =>
    {
        Console.WriteLine("Resolve {0}", eventArgs.Name);
        Console.WriteLine(Resource1.String1);
        return null;
    };
    
    Console.WriteLine(Resource1.String1);
