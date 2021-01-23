    container.RegisterCollection(typeof(MyFactory), Assembly.GetExecutingAssembly());
    var namespaceTypes =
        from type in Assembly.GetExecutingAssembly().GetTypes()
        where type.Namespace == typeof(MyClass).Namespace
        select type;
    foreach (Type type in namespaceTypes)
        container.Register(type, type, Lifestyle.Singleton);
