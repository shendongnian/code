    var changedEntries = dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
    foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
    {
        entry.State = EntityState.Unchanged;
        _ctx.Entry<Users>(SelectedUser).Reload(); //SelectedUser is the one which will get reloaded.
    }
