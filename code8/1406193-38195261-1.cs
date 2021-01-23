    
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
The transaction will rollback if scope.Complete() has not been called. You will need to add a reference to System.Transactions if your project doesn't have it already.
