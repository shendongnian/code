    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, 
           new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted, 
                                    Timeout = TransactionManager.MaximumTimeout }))
    {
        try {
            _repository.InsertToDB(person1);
            _repository.UpdateToDB(person2);
            scope.Commit();
        } catch (Exception) {
            scope.RollBack();
        }
        scope.Complete();
    }
