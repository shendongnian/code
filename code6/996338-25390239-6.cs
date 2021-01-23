    public class Repository<T> where T : class {
        public Repository(DbContext dataContext) { context = dataContext; }
        public IQueryable<T> GetAll() { return context.Set<T>(); }
        private readonly DbContext context;
    }
