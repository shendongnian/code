     public class GenericRepository<T> : where T : class
     {
        internal YourConext context;
        internal DbSet<T> dbSet;
        public GenericRepository(YourContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
      }
