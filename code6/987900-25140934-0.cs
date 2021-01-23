    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany
        (x => x.GetTypes()
            .Where(t => t.GetCustomAttribute<ANAttribute>() != null &&
                        t.GetCustomAttribute<ANAttribute>().YourProperty == "Ampe21")
        );
    foreach (var type in types)
    {
        Console.WriteLine(type.Namespace);
    }
