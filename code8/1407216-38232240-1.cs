    //  Get the entity type by reflection too, so we don't have to worry about
    //  crashing on an empty list. 
    Type entityType = lstItemsModifiedSinceLastSync.GetType().GenericTypeArguments.First();
    MethodInfo method = importService.GetType().GetMethod("Import");
    MethodInfo generic = method.MakeGenericMethod(entityType);
    generic.Invoke(importService, new object[] { 
            lstItemsModifiedSinceLastSync, 
            currentJobQEntry, 
            session, 
            financialsIntegrationContext
        });
