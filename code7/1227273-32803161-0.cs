    #if DEBUG
    db.ChangeTracker.DetectChanges(); // Force EF to match associations.
    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
    var objectStateManager = objectContext.ObjectStateManager;
    var fieldInfo = objectStateManager.GetType().GetField("_entriesWithConceptualNulls", BindingFlags.Instance | BindingFlags.NonPublic);
    var conceptualNulls = fieldInfo.GetValue(objectStateManager);
    #endif
