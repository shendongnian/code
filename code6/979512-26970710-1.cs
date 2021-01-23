    public override int SaveChanges()
    {
        foreach ( var entry in ChangeTracker.Entries()
              .Where( p => p.State == EntityState.Deleted ) )
        SoftDelete( entry );
        return base.SaveChanges();
    }
    private void SoftDelete( DbEntityEntry entry )
    {
        Type entryEntityType  = entry.Entity.GetType();
        string tableName      = GetTableName( entryEntityType );
        string primaryKeyName = GetPrimaryKeyName( entryEntityType );
        string deletequery = string.Format(
            "UPDATE {0} SET IsDeleted = 1 WHERE {1} = @id", 
            tableName, primaryKeyName);
        Database.ExecuteSqlCommand(
            deletequery,
            new SqlParameter("@id", entry.OriginalValues[primaryKeyName] ) );
 
        // Marking it Unchanged prevents the hard delete
        //   entry.State = EntityState.Unchanged;
        // So does setting it to Detached:
        // And that is what EF does when it deletes an item
        // http://msdn.microsoft.com/en-us/data/jj592676.aspx
        entry.State = EntityState.Detached;
    }
