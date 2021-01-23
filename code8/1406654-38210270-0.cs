    public abstract class Repository<TEntity> : IRepository 
        where TEntity : Repository<TEntity>, new()
    {
        public TEntity Map()
        {
            TEntity clone = new TEntity();
            // (Snip)
            return clone;
        }
    }
