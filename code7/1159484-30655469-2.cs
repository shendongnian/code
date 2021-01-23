    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, 
           new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted, 
                                    Timeout = TransactionManager.MaximumTimeout }))
    {
        _repository.InsertToDB(person1);
        _repository.UpdateToDB(person2);
        // if exception occurs, Complete will not get called, so transaction
        // is automatically rolled back when Dispose is called when using()
        // goes out of scope.  If Complete is called, then Commit is called.
        scope.Complete();
    }
