    public class YourDbContext : DbContext
    {
        ...
        public bool Exists<TEntity>(object id)
            where TEntity : class
        {
            var entity = Set<TEntity>.Find(id);
            return entity != null;
        }
