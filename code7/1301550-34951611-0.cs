    static MyDbContext()
    {
        // You should see this...
        Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
        // ... or this ...
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
    }
