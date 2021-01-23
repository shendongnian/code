    public override int SaveChanges()
    {
        var selectedEntityList = ChangeTracker.Entries()
                                .Where(x => x.Entity is EntityInformation &&
                                (x.State == EntityState.Added || x.State == EntityState.Modified));
        foreach (var entity in selectedEntityList)
        {
            ((EntityInformation)entity.Entity).Date = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.ToUniversalTime());
        }
        return base.SaveChanges();
    }
