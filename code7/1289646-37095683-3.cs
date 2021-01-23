    public override int SaveChanges()
    {
        int? userId = null;
        if (System.Web.HttpContext.Current != null)
            userId = (from user in Users.Where(u => u.UserName == System.Web.HttpContext.Current.User.Identity.Name) select user.Id).SingleOrDefault();
            
        var modifiedBidEntries = ChangeTracker.Entries<User>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach (EntityEntry<User> entry in modifiedBidEntries)
        {
            entry.Property("Modified").CurrentValue = DateTime.UtcNow;
            entry.Property("ModifiedById").CurrentValue = userId;
            if (entry.State == EntityState.Added)
            {
                entry.Property("Created").CurrentValue = DateTime.UtcNow;
                entry.Property("CreatedById").CurrentValue = userId;
            }
        }
        return base.SaveChanges();
    }
