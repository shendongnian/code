    AppDomain ad = AppDomain.CurrentDomain;
    Assembly[] loadedAssemblies = ad.GetAssemblies();
    Console.WriteLine("Here are the assemblies loaded in this appdomain\n");
    foreach (Assembly a in loadedAssemblies)
    {
        Console.WriteLine(a.FullName);
    }
