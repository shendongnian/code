    public class Repository<T> : Interfaces.Repositories.IRepository<T> where T : class
    {
        protected readonly IDbContext Context;
    
        public Repository(IDbContext context)
        {
            Context = context;
        }
    
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }
    
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
    
        public T Get(int ID)
        {
            return Context.Set<T>().Find(ID);
        }
    
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    
        public void Remove(T item)
        {
            Context.Set<T>().Remove(item);
        }
    }
