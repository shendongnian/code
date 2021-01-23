    using (TransactionScope scope = new TransactionScope())
    {
        // Assuming you are using SQL Server....
        using (SqlConnection conn = new SqlConnection(connectString1))
        {
            conn.Open();
            InsertToTable1(conn);
            // Snip...
            InsertToTable5(conn);
            // If this point is reached, everything is tickety boo            
            // Commit the transaction using Complete.
            // If the scope.Complete line is not hit before the using block 
            // is exited (i.e. an Exception is thrown, the transaction is rolled               
            // back.
            scope.Complete();
        }
    }
