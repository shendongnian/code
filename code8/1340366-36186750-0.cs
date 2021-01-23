    using (TransactionScope scope = new TransactionScope())
    using (var con= new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString))
    {
        try
        {
           // many transactions
           scope.Complete();
        }
        catch (Exception e)
        {
            // Not needed any rollback, if you don't call Complete
            // a rollback is automatic exiting from the using block
            // con.BeginTransaction().Rollback();
        }
    }
