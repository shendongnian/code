    
    try
    {
        using (var scope = new TransactionScope())
        {
            // insert statement to EnrolledSubjects table;
            // insert statement to StudentAccounts table;
            scope.Complete(); // don't forget this!
        }
    }
    catch(Exception ex)
    {
        // get error here
    }
The transaction will rollback if scope.Complete() has not been called.
