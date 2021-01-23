    public static void RegisterEntityFramework(this Container container, 
        ScopedLifestyle lifestyle)
    {
        var contextRegistration =
            lifestyle.CreateRegistration<EntityDbContext, EntityDbContext>(container);
        container.AddRegistration(typeof(EntityDbContext), contextRegistration);
        container.AddRegistration(typeof(IUnitOfWork), contextRegistration);
    }
