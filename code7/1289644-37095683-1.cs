    public override int SaveChanges()
    {
        int? userId = null;
        if (System.Web.HttpContext.Current != null)
            userId = (from user in Users.Where(u => u.UserName == System.Web.HttpContext.Current.User.Identity.Name) select user.Id).SingleOrDefault();
        var modifiedEntries = ChangeTracker.Entries<IAuditableEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach (EntityEntry<IAuditableEntity> entry in modifiedEntries)
        {
            entry.Entity.ModifiedById = UserId;
            entry.Entity.Modified = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedById = UserId;
                entry.Entity.Created = DateTime.Now;
            }
        }
            
        return base.SaveChanges();
    }
