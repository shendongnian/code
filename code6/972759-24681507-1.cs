    public MyExistingDatabaseContext : DbContext
    {
        public MyExistingDatabaseContext()
            : base("MyExistingDatabaseConnectionStringName")
        {
            Database.SetInitializer<MyExistingDatabaseContext>(null);
        }
        // DbSets here
    }
