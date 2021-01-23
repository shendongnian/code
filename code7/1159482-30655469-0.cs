    using (TransactionScope scope = new TransactionScope(IsolationLevel.ReadCommitted))
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
