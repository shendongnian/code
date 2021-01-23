    string connectionString = "YourConnectionString";
    int parameter = 0;
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "NameOfYourStoredProcedure";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("ParameterName", parameter);
        try
        {
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Read your reader data
                }
            }
        }
        catch
        {
            throw;
        }
    }
