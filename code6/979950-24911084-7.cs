    public class EFUnitOfWork: IUnitOfWork
    {
        private DbContext _db;
        public EntityFrameworkSourceAdapter(DbContext context) {...}
        public void Add<T>(T item) where T : class, new() {...}
        public void AddAll<T>(IEnumerable<T> items) where T : class, new() {...}
        public T Get<T>(Expression<Func<T, bool>> filter) where T : class, new() {...}
        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> filter = null) where T : class, new() {...}
        public void Update<T>(T item) where T : class, new() {...}
        public void Remove<T>(Expression<Func<T, bool>> filter) where T : class, new() {...}
        public void Commit() {...}
        public void Dispose() {...}
    }
