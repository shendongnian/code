    foreach (var track in dbContext.ChangeTracker.Entries())
    {
         if (track.State == EntityState.Deleted)
             Entity s = (Entity)track.OriginalValues.ToObject();
         else
             Entity s = (Entity)track.CurrentValues.ToObject();
    }
