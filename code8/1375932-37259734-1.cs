    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            /*do something*/
            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }
    }
