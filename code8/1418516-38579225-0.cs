    using (IDbConnection conn = new SqlConnection(DataBaseConnectionString))
    {
       conn.Open();
    
       // If you want transaction, place it inside the query. 
       var entities = conn.Query<ResuleModel>(@"SELECT col1, col2, col3 ...");
    
       result = entities.ToList();
    }
