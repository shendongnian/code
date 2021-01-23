    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyTempEntity : MyEntity
    {
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        { }
        public MyDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<MyTempEntity> MyTempEntities { get; set; }
    }
