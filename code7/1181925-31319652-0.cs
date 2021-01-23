    MyEntity changedEntityToSubmit; // first you need to know what is the entity you need to submit.
    List<object> allChangedEntities = new List<object>(myDataContext.GetChangeSet().Inserts);
    allChangedEntities.Remove(changedEntityToSubmit);
    
    myDataContext.Refresh(RefreshMode.OverwriteCurrentValues, allChangedEntities);
    
