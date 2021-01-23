    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
    {
        ...
        context.SaveChanges();
        scope.Complete();
    }
