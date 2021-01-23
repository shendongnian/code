    using (var ts = new System.Transactions.TransactionScope())
    {
        using (var context = new DbContext("test"))
        {
            ... // more code here
            context.Database.ExecuteSqlCommand("SomeStoredProcedure");
            context.SaveChanges();
        }
        ts.Complete();
    }
