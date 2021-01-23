    public override int SaveChanges()
    {
        // fix trackable entities
        var trackables = ChangeTracker.Entries<ITrackableEntity>();
        if (trackables != null)
        {
            // added
            foreach (var item in trackables.Where(t => t.State == EntityState.Added))
            {
                item.Entity.CreatedDateTime = System.DateTime.Now;
                item.Entity.CreatedUserID = _userID;
                item.Entity.ModifiedDateTime = System.DateTime.Now;
                item.Entity.ModifiedUserID = _userID;
            }
            // modified
            foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
            {
                item.Entity.ModifiedDateTime = System.DateTime.Now;
                item.Entity.ModifiedUserID = _userID;
            }
        }
        return base.SaveChanges();
    }
