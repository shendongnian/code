    public class dbMyContext : DbContext
    {
        //snip
        public dbMyContext(DbConnection existingConnection, boolcontextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }
        public dbMyContext(string connectionString) : base(connectionString) { }
        //snip
    }
