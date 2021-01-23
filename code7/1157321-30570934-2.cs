    IEnumerable<ObjectStateEntry> objectStateEntries = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added | EntityState.Deleted);
    foreach (ObjectStateEntry entry in objectStateEntries)
    {
        if (!entry.IsRelationship && entry.Entity.GetType() == typeof(CustomerTransfer) && entry.State == EntityState.Deleted)
        {
            // Do some magic if the entity type is a CustomerTransfer that has been deleted.
        }
    }
