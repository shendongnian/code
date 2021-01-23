    public int SaveChanges<TEntity>() where TEntity : class
    {
        var original = this.ChangeTracker.Entries()
                    .Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType()) && x.State != EntityState.Unchanged)
                    .GroupBy(x => x.State)
                    .ToList();
                    
        foreach(var entry in this.ChangeTracker.Entries().Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType())))
        {
            entry.State = EntityState.Unchanged;
        }
        var rows = base.SaveChanges();
        foreach(var state in original)
        {
            foreach(var entry in state)
            {
                entry.State = state.Key;
            }
        }
                
        return rows;
    }
