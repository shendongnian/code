    string queryOne = @"SELECT * FROM DbOne";
    string queryTwo = @"SELECT * FROM DbTwo";
    
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionString("db"))
    {
         using(SqlCommand command = new SqlCommand(queryOne, connection))
         {
            // Logic
         }
    
         using (SqlCommand command = new SqlCommand(queryTwo, connection))
         {
            // Logic
         }
    }
