    public override int SaveChanges()
    {
        var modifiedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified).ToArray();
        var rowsAffected = base.SaveChanges();
        foreach (var entity in modifiedEntities)
            entity.State = EntityState.Detached;
        return rowsAffected;
    }
