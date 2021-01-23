    ....
    foreach( var entry in context.ChangeTracker.Entries<TrackedEntity>())
    {
        if(entry.State!=EntityState.Unchanged)
        {
            TrackedEntity entity = entry.Entity;
            entity.Modified = DateTime.UtcNow;
            entity.ModifiedBy = username;
        }
    }
    context.SaveChanges();
