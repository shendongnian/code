    var scopedLifestyle = new WebRequestLifestyle();
    var contextRegistration =
        scopedLifestyle.CreateRegistration<EntityDbContext, EntityDbContext>(container);
    container.AddRegistration(typeof(EntityDbContext), contextRegistration);
    container.AddRegistration(typeof(IUnitOfWork), contextRegistration);
