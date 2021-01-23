    public abstract RepositoryBase<T>
    {
        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
    
        public void Remove(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
    
        etc...
    }
