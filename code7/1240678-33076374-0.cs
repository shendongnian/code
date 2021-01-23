    using (var context = new TestContext())
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<EntityContext>());
        context.Database.Initialize(true);
    }
