    public class MyDbSet<TEntity> : DbSet<TEntity>, IMyDbSet<TEntity> where TEntity : class
    {
    }
    public interface IMyDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> items);
    }
