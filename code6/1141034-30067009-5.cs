    public class BlogEngineRepository<T> : IRepository<T> where T : class
        {
            protected DbSet<T> DbSet;
    
            public BlogEngineRepository(DbContext dataContext)
            {
                DbSet = dataContext.Set<T>();
            }
    
            #region IRepository<T> Members
    
            public void Insert(T entity)
            {
                DbSet.Add(entity);
            }
    
            public void Delete(T entity)
            {
                DbSet.Remove(entity); 
            }
    
            public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
            {
                return DbSet.Where(predicate);
            }
    
            public IQueryable<T> GetAll()
            {
                return DbSet;
            }
    
            public T GetById(int id)
            {
                return DbSet.Find(id);
            }
    
        }
