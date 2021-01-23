    class SchoolDbContext : DbContext
    {
        // the standard constructors you probably already use:
        public SchooldDbContext() : base(...) {}
        public SchoolDbContext(string nameOrConnectionString) : base(nameOrConnectionString) {}
        // add this one for effort:
        public SchoolDbContext(DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection) { }
        ... // DbSets, etc
