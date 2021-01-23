    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (var trn = conn.BeginTransaction("TransactionName"))
        {
            using (var db = new MyContext(conn, false))
            {
                db.Database.UseTransaction(trn);
                ... // your code here
            }
        }
    }
