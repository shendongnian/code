    public interface IRepository<TEntity, TContext> : IDisposable
        where TEntity : class 
        where TContext : IDbContext, new()
    {
    ...
    }
