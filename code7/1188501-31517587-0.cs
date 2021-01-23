    using (TransactionScope scope = new TransactionScope())
    {
       foreach (EditedRule editedRules in request.EditedRules)
       {
           // stored proc
       }
       scope.Complete();
    }
