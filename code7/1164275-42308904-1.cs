    public override int SaveChanges()
    {
        var modifiedEntries = base.ChangeTracker.Entries<MyObject>()
            .Where(e => e.State == EntityState.Modified).ToList();
        foreach (var entry in modifiedEntries)
        {
             // Overwriting with the same value doesn't count as change.
             entry.CurrentValues["HistoricDataColumnName"] = entry.OriginalValues["HistoricDataColumnName"];
        }
        return base.SaveChanges();
    }
