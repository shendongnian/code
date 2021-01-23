        using (var scope =  new TransactionScope(
             TransactionScopeOption.Required, 
             new TransactionOptions() {
             IsolationLevel = IsolationLevel.ReadCommitted
           }))
        {
        using (var conn = new SqlConnection(connString))
        {
           conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                // Loop the Insert operation here 
                cmd.CommandText = "INSERT Operation";
                cmd.ExecuteNonQuery();
            }                
        }    
         scope.Complete();
        } 
