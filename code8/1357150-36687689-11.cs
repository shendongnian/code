    public interface IDbContext : IDisposable, IObjectContextAdapter
    {
            IDbSet<Request> Requests { get; set; }
            IDbSet<Record> Records { get; set; }
            int SaveChanges();
    
            DbSet Set(Type entityType);
            DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
