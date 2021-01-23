    string connStr = "...; Enlist = false";
    using (TransactionScope ts = new TransactionScope())
    {
        using (SqlConnection conn1 = new SqlConnection(connStr))
        {
            conn1.Open();
            conn1.EnlistTransaction(Transaction.Current);
        }
    }
