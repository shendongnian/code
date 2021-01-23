    try
    {
        using (TransactionScope scope = new TransactionScope())
        {
            database1.Connection.EnlistTransaction(Transaction.Current);
            database2.Connection.EnlistTransaction(Transaction.Current);
            //Insert into database1 (getting the deadlock issue)
            database1.SaveChanges();
            //Update ExternalId (Identity PK from database1) in database2
            database2.SaveChanges();
            scope.Complete();
        }
    }
    catch (Exception ex)
    {
        throw;
    }
