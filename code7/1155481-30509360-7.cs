	public override int SaveChanges()
	{
    	this.UpdateTrackedEntities();
		return base.SaveChanges();
	}
    public override async Task<int> SaveChangesAsync()
	{
		this.UpdateTrackedEntities();
		return await base.SaveChangesAsync();
	}
    private void UpdateTrackedEntities()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is ITrackedEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
		foreach (var entity in entities)
		{
			if (entity.State == EntityState.Added)
			{
				((ITrackedEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
			}
			((ITrackedEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
		}
    }
