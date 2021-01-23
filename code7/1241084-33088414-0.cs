    //you need to call DetectChanges
    ((IObjectContextAdapter)context).ObjectContext.DetectChanges();
    var addedRelations = ((IObjectContextAdapter)context).ObjectContext
                                  .ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                                     .Where(e=>e.IsRelationship).ToList();
