    container = TestContainerFactory.SetupContainer(id);
    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDb, Configuration>());
    var applicationDb = container.GetInstance<ApplicationDb>();    
    if (applicationDb.Database.Exists()) //just in case the previous test didn't delete the old db
    {
        applicationDb.Database.Delete();
    }
    applicationDb.Database.Initialize(true);
