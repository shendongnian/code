	public override int SaveChanges()
	{
    	this.UpdateTrackedEntities();
		return base.SaveChanges();
	}
    public override Task<int> SaveChangesAsync()
	{
		this.UpdateTrackedEntities();
		return base.SaveChangesAsync();
	}
    private void UpdateTrackedEntities()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is ITrackableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
		foreach (var entity in entities)
		{
			if (entity.State == EntityState.Added)
			{
				((ITrackableEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
			}
			((ITrackableEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
		}
    }
