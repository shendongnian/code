    protected void ExecuteInTransaction(Action action)
    {
        using (var transaction = connection.BeginTransaction())
        {
            action.Invoke();
            transaction.Commit();
        }
    }
