    public class MyRepository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : class 
        where TContext : IDbContext, new()
    {
    ...
    }
