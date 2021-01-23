    // your application specific context
    public class MySpecificApplicationContext : DbContext { }
    // get your entity types that a given application uses
    var entityTypes = GetEntityTypes();
    // register a repository implementation for each entity type
    // note RepositoryBase is not abstract for this example
    for (var i = 0; i < entityTypes.Count; i++)
    {
        var entityType = entityTypes[i];
        builder
            .RegisterType(typeof (RepositoryBase<,>)
            .MakeGenericType(typeof (MySpecificApplicationContext), entityType))
            .As(typeof (IRepository<>).MakeGenericType(entityType))
            .InstancePerLifetimeScope();
    }
    // resolve an entity repository
    var userRepository = container.Resolve<IRepository<User>>();
