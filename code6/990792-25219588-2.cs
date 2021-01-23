    public class YourDbContext : DbContext
    {
        ...
        public bool Exists<TEntity>(object id)
            where TEntity : class
        {
            var dbSet = Set<TEntity>();
            var entity = dbSet.Find(id);
            return entity != null;
        }
