    using (var db = new MyDbContext())
    {
        // gets the metadata about all entity types
    	IEnumerable<IEntityType> entityTypes = db.Model.GetEntityTypes();
    	foreach (var entityType in entityTypes)
    	{
    		Type pocoType = entityType.ClrType;
    	}
    }
