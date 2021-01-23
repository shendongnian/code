    using(SqlConnection connection = new SqlConnection("connection_String"))
    {
        string query = "INSERT INTO table_name (column_name) VALUES (@val1)";
    
        using(SqlCommand inputQuery = new SqlCommand(query))
        {
            inputQuery.Connection = openCon;
            inputQuery.Parameters.AddWithValue("@val1", DBNull.Value);
            try
            {
                connection.Open();
                int recordsAffected = inputQuery.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                // error here
            }
            finally
            {
                connection.Close();
            }
        }
    }
