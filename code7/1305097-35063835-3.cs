    using (var ctx = new TestContext())
    {
    	Entity ent = entity.Single(x => x.Id == id);
    	entity.FirstName = "New name";
    
    	context.ChangeTracker.DetectChanges();
        // Find your entry or get all changed entries
    	var changes = context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
    																 
    	foreach (var objectStateEntry in changes)
    	{
    		AuditEntityModified(audit, objectStateEntry, auditState);
    	}
    }
    
    public static void AuditEntityModified(Audit audit, AuditEntry entry, EntityEntry objectStateEntry)
    {
    	foreach (var propertyEntry in objectStateEntry.Metadata.GetProperties())
    	{
    		var property = objectStateEntry.Property(propertyEntry.Name);
    
    		if (entry.Parent.CurrentOrDefaultConfiguration.IsAudited(entry.ObjectStateEntry, propertyEntry.Name))
    		{
    			entry.Properties.Add(new AuditEntryProperty(entry, propertyEntry.Name, property.OriginalValue, property.CurrentValue));
    		}
    	}
    }
