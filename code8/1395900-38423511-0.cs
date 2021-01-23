    public interface IDbContext : IDisposable {
        int SaveChanges();
    }
    public interface IBloggingContext : IDbContext {
        DbSet<Blog> Blogs { get; }
        DbSet<Post> Posts { get; }
    }
