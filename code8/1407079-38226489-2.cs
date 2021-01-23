    using (var conn = new SqlConnection("myConnectionString"))
    {
        conn.Open();
        using (var scope = new TransactionScope(...))
        {
            foreach(var foo in foos)
            {
                db.Add(foo, conn);
            }
    
            scope.Complete();
        }
    }
