    foreach(Type enumType in Assembly.GetExecutingAssembly().GetTypes()
                            .Where(x => x.IsSubclassOf(typeof(Enum)) &&
                                   x.GetCustomAttribute<HelloWorldAttribute>() != null))
    {
        Console.WriteLine(enumType.Name);
    }
