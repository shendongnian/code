    Type entityType = lstItemsModifiedSinceLastSync.FirstOrDefault().GetType();
    MethodInfo method = importService.GetType().GetMethod("Import");
    MethodInfo generic = method.MakeGenericMethod(entityType);
    generic.Invoke(importService, new object[] { 
            lstItemsModifiedSinceLastSync, 
            currentJobQEntry, 
            session, 
            financialsIntegrationContext
        });
