    public override void SaveChanges()
    {
        UploadedFile[] newFiles = base.ChangeTracker.Entries<UploadedFile>()
                        .Where(x => x.State == EntityState.Added)
                        .Select(x => x.Entity)
                        .ToArray()
        
        base.SaveChanges();
        
        //id values should be available to you here in the newFiles array
    }
