    public static void Raise<T>(T args) where T : IDomainEvent
    {
        ...
        Container.ResolveAll<IHandle<T>>();   
    }
