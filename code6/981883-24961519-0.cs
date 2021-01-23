    private void Main()
    {
        // Instantiate action variable. I know this wouldn't work, but it's just for show.
        Action myAction;
        try
        {
            ExecuteInTransaction(myAction);
        }
        catch(Exception ex)
        {
            Debug.WriteLine("Error happened and transaction rolled back. " + ex.Message);
        }
    }
    protected void ExecuteInTransaction(Action action)
    {
        using (SQLiteTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                action.Invoke();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
