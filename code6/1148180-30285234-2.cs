    // Simple Injector v3.x
    container.RegisterCollection<Animal>(new[] {
        typeof(Cat), 
        typeof(Dog), 
        typeof(Pig)
    });
    // or
    container.RegisterCollection<Animal>(
        from type in typeof(Animal).Assembly.GetTypes()
        where type.IsSubclassOf(typeof(Animal))
        select type);
    // Simple Injector v2.x
    container.RegisterAll<Animal>(new[] {
        typeof(Cat), 
        typeof(Dog), 
        typeof(Pig)
    });
