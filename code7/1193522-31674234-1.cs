    ...
    String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (SqlCommand command = new SqlCommand(@"your_sql_command"))
        {
             using (SqlDataReader reader = command.ExecuteReader())
             {
                 while (reader.Read())
                 {
                      //do stuff
                 }
             }
        }
    }
