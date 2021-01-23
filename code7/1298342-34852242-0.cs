    using (SqlConnection con = new SqlConnection(connectionString))
    {
     con.Open();
     using (SqlCommand cmd = new SqlCommand())
     {
     cmd.CommandText = "TRUNCATE TABLE [TableName];"
     cmd.Connection = con;
     cmd.ExecuteNonQuery();
     }
    }
