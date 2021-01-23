    public override int SaveChanges()
    {
    	ChangeTracker.DetectChanges();
    	var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();
    	var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
    	var deletedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted).ToList();
    	
    	//Save info generating the ids
    	var ret = base.SaveChanges();
    	
    	//Generate Logs logic
    	...
    	
    	return ret;
    }
