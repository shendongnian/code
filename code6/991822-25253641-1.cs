    string query = @"SELECT * FROM [FirstDataBase].[dbo].[table1]
        INNER JOIN [SecondDataBase].[dbo].[table2]";
    
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionString[@"db"].ConnectionString))
         using(SqlCommand command = new SqlCommand(query, connection))
         {
             // Logic
         }
