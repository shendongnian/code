    kernel.Bind(x => x
        .FromThisAssembly()
        .SelectAllClasses()
        .InheritedFrom<IInterface>()
        .BindAllInterfaces()
        .Configure((syntax, type) => syntax.Named(GetKeyFrom(type))));
    private static string GetKeyFrom(Type type)
    {
        return type
            .GetCustomAttributes(typeof(KeyAttribute), false)
            .OfType<KeyAttribute>()
            .Single()
            .Key;
    }
