    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public virtual DbSet<MyModel> MyModel { get; set; }
    }
