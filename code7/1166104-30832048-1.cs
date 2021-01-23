    class GenericRepository<T>: IRepository<T> where T: class
    {
        public virtual List<T> GetAll()
        {
            using(var context = new DbContext())
            {
                return content.Set<T>().ToList();
            }
        }
    
        public virtual void Add(T entity)
        {
            using(var context = new DbContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public virtual void Update(T entity)
        {
            using(var context = new DbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public virtual void Remove(T entity)
        {
            using(var context = new DbContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
