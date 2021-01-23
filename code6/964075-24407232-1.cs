    public interface IRepository<TEntity, in TKey>
    {
        TEntity Get(TKey id);
        TEntity GetById(int id);
        IQueryable<TEntity> All();
    }
    public abstract class Repository : IRepository
    {
        public virtual TEntity Get(TKey id) { throw new NotImplementedException(); }
        public virtual TEntity GetById(int id) { throw new NotImplementedException(); }
        public virtual IQueryable<TEntity> All() { throw new NotImplementedException(); }
    }
    public class FullRepo : Repository
    {
        public virtual TEntity Get(TKey id) { /*Implement it!*/ }
        public virtual TEntity GetById(int id) { /*Implement it!*/ }
        public virtual IQueryable<TEntity> All() { /*Implement it!*/ }
    }
    // No GetById here
    public class PartialRepo : Repository
    {
        public virtual TEntity Get(TKey id) { /*Implement it!*/ }
        public virtual TEntity GetById(int id) { throw new NotSupportedException(); }
        public virtual IQueryable<TEntity> All() { /*Implement it!*/ }
    }
