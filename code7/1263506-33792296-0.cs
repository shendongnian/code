    var scopeOptions = new TransactionOptions();
    scopeOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
    scopeOptions.Timeout = TimeSpan.MaxValue;
    using (var ts = new TransactionScope(TransactionScopeOption.Required, scopeOptions))
    {
        using (var scope1 = new TransactionScope(TransactionScopeOption.Required))
        {
            // if you can wrap a using statment around the db context here that would be good
            db.Product.Add(product);
            db.SaveChanges();
            scope1.Complete();
        }
        using (var scope2 = new TransactionScope(TransactionScopeOption.Required))
        {
            // omitted the other "using" statments for the connection/command part for brevity
            var sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Monet"].ConnectionString);
            sqlConn.Open();
            SqlCommand sqlCommand = sqlConn.CreateCommand();
            sqlCommand.CommandText = InsertMonetProduct(product);
            sqlCommand.ExecuteNonQuery(); // if this fails, the parent scope will roll everything back
            scope2.Complete();
        }
        ts.Complete();
    }
