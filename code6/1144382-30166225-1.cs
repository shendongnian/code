    var changedEntries = dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
    foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
    {
        //No need to set entry to Unchanged
        entry.Reload();
    }
