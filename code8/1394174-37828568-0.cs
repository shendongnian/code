    interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
    public class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext()
            : base("myConnectionString")
        { }
        //implementation
    }
