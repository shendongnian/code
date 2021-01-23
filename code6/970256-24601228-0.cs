    ....
    foreach( var entry in context.ChangeTracker.Entries<TrackedEntity>())
    {
        TrackedEntity entity = entry.Entity;
        entity.Modified = DateTime.UtcNow;
        entity.ModifiedBy = username;
    }
    context.SaveChanges();
