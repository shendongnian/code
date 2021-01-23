    var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
    foreach (DbEntityEntry entity in modifiedEntries)
    {
        foreach (var propName in entity.CurrentValues.PropertyNames)
        {
            var current = entity.CurrentValues[propName];
            var original = entity.OriginalValues[propName];
        }
    }
