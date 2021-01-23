    using (var transaction = db.Database.BeginTransaction()) 
    {
        // Applies the changes
        this.ApplyChanges(db, entityType, entityId, propertyValues);
        db.SaveChanges();    
    
        // Should be true
        var hasEntityWithValue = db.MyEntity.Any(p => p.Id == entityId && p.MyProperty1!=null);
        // At this point, queries to the database will see the updates you made 
        // in the ApplyChanges method
        var isValid = ValidateSave();
        if (isValid)
        {
            // Assuming no more changes were made since you called db.SaveChanges()
            transaction .Commit(); 
        }
        else
        {
            transaction .Rollback(); 
        }
    }
