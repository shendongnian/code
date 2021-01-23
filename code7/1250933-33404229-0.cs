    public int SaveChanges<TEntity>() where TEntity : class
    {
        var original = this.ChangeTracker.Entries()
                    .Where(x => x.Entity.GetType() != typeof(TEntity) && x.State != EntityState.Unchanged)
                    .GroupBy(x => x.State)
                    .ToList();
                    
        foreach(var entry in this.ChangeTracker.Entries().Where(x => x.Entity.GetType() != typeof(TEntity)))
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
