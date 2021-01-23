    public class BlogEngineRepository<T> : IRepository<T> where T : class
    {
      public BlogEngineRepository(DbContext dataContext)
      {
        DbSet = dataContext.Set<T>();
        Context = dataContext;
      }
      public T Update(T entity)
      {
         DbSet.Attach(entity);
         var entry = Context.Entry(entity);
         entry.State = System.Data.EntityState.Modified;
      }
    }
