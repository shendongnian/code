    // get type of the Entity we need
    var entityType = typeof(TEntity);
    // get persister
    var entityType = typeof(TEntity);
    var factory = ... // get factory
    var persister = factory.GetClassMetadata(entityType) as AbstractEntityPersister;
    // check this setting
    var hasCascades = persister.HasCascades;
    // use it somehow
    return hasCascades
