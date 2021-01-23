    try
    {
       // the parameter tells it go ahead and update all non-conflicting items
       // afterwards it'll throw having all conflicting items stored
       dbContext.SubmitChanges(ConflictMode.ContinueOnConflict);
    }
    catch (ChangeConflictException ex)
    {
       foreach (ObjectChangeConflict o in dbContext.ChangeConflicts)
         o.Resolve(RefreshMode.KeepChanges); // Resolve the conflicts, not just
                                             // refresh the context
       dbContext.SubmitChanges(); // and submit again
    } 
