    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(nameOrConnectionString: "MyEntities") { }
        public virtual DbSet<Users> Users { get; set; }
    }
