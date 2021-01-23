    protected void Add<T>(T source, MyEntities context, bool isNew, EntityState state) 
        where T : class
    {
        IDbSet<T> set = context.Set<T>();
        if (isNew)
        {
            set.Add(source);
        }
        else
        {
            if (state == EntityState.Detached)
            {
                set.Attach(source);
                
                DbEntityEntry<T> entry = set.Entry(source); 
                entry.State = EntityState.Modified; 
            }
        }
    }
