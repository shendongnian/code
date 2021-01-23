    using (var sqlConnection = GetSqlConnection(...))
    {
        try (sqlConnection.Open()
        {   // before making the changes: remember the state of the database
            using (var transaction = sqlConnection.BeginTransaction())
            {
                bool changesOk = true;
                try
                {
                    changesOk = ChangeDatabase(...);
                }
                catch (Exception exc)
                {
                    changesOk = false;
                }
    
                if (!changesOk)
                {   // go back to the state at the beginning of the transaction
                    transaction.RollBack();
                }
                else
                {   // no error: save the changes:
                    transaction.Commit();
                }
            }
        }
    }
