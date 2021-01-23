    AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) =>
    {
        Console.WriteLine("Resolve {0}", eventArgs.Name);
        return null;
    };
    Console.WriteLine(Resource1.String1);
    Console.WriteLine(Resource1.String1);
