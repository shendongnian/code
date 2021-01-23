    public interface IRepository<T> where T : class
        {
            DbContext GetContext();
            IQueryable<T> GetAll();
            IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
            void Add(T entity);
            void Delete(T entity);
            void DeleteAll(IEnumerable<T> entity);
            void Edit(T entity);
            bool Any();
        }
-----------------------------
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        
        public virtual DbContext GetContext()
        {
            return _context;
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsQueryable();
            return query;
        }
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }
        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
            _dbset.Remove(entity);
        }
        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            foreach (var ent in entity)
            {
                var entry = _context.Entry(ent);
                entry.State = EntityState.Deleted;
                _dbset.Remove(ent);
            }
        }
        public virtual void Edit(T entity)
        {
            var entry = _context.Entry(entity);
            _dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }
        public virtual bool Any()
        {
            return _dbset.Any();
        }
    }
