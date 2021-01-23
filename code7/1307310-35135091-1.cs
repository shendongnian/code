    // Easy to use
    context.BulkSaveChanges();
    
    // Easy to customize
    context.BulkSaveChanges(operation => operation.BatchSize = 1000);
    
    // For direct bulk insert
    var theEntities = ctx.ChangeTracker.Entries<BaseEntity>().Select(x => x.Entity).ToList();
    context.BulkInsert(theEntities);
