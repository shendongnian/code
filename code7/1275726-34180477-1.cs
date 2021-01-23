    // This assignment could happend AFTER the inner assignment.
    _businessObjectTask = businessObjectService.GetData(CancellationToken.None)
        .ContinueWith
        (
            t => 
            {
               // This assignment could happen BEFORE the outer assignment.
                _businessObjects = t.Result.ToDictionary(e => e.ItemId);              
