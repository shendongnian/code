    public class Entity
    {}
    public class Tenant
    {}
    public class AbpUser<T1, T2>
    {}
    public Context(DbConnection connection)
        : base(connection, false)
    {
    }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AdImage> AdImages { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Advertisements)
            .WithRequired(x => x.User);
        modelBuilder.Entity<Advertisement>()
            .HasMany(a => a.AdImages)
            .WithRequired(x => x.Advertisement);
        modelBuilder.Entity<AdImage>()
            .HasRequired(x => x.Advertisement);
        base.OnModelCreating(modelBuilder);
    }
