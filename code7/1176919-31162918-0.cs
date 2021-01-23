    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class Model6Context : DbContext
    {
        public Model6Context(DbConnection connection)
            : base(connection, false)
        { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
    }
