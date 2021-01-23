    foreach (Type type in from e in GetAllTypesInDll(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Console.exe"))
                          orderby e.FullName
                          select e)
    {
        // print type
        Console.WriteLine("----------------");
        Console.WriteLine(type.FullName);
    
        // print type methods
        Console.WriteLine("Methods:");
        foreach (var mi in from e in type.GetMethods()
                           orderby e.Name
                           select e)
        {
            Console.WriteLine("    " + mi.Name);
        }
        Console.WriteLine("----------------");
    }
