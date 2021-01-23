    public Db(): base("Db")
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db,
                                          Migrations.Configuration>());
    }
