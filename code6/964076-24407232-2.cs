    // No GetById here
    public class PartialRepo : Repository
    {
        public virtual TEntity Get(TKey id) { /*Implement it!*/ }
        [Obsolete("This method can't be used by this repository", true)]
        public virtual TEntity GetById(int id) { /*Can be empty*/ }
        public virtual IQueryable<TEntity> All() { /*Implement it!*/ }
    }
