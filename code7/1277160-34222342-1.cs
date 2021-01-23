    protected void Add<T>(T source, MyEntities context, bool isNew) 
        where T : class
    {
        IDbSet<T> set = context.Set<T>();
        if (isNew)
        {
            set.Add(source);
        }
        else
        {
            DbEntityEntry<T> entry = set.Entry(source); 
            if (entry.State == EntityState.Detached)
            {
                set.Attach(source);
                entry.State = EntityState.Modified; 
            }
        }
    }
