    public class TestContext : DbContext
    {
        public TestContext(DbConnection connection) : base(connection, true) { }
        public DbSet<InternCode> InternCodes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Version> Versions { get; set; }
    }
