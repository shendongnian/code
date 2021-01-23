    public SqlDataReader FetchAll(string tableName)
    {
        SqlDataReader reader;
        using (SqlConnection conn = new SqlConnection(_ConnectionString))
        {
            string query = "SELECT * FROM  " + tableName;
            // added using block for your command (thanks for pointing that out Alex K.)
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open(); // <-- moved this ABOVE the execute line.
                reader = command.ExecuteReader(); // <-- using the reader declared above.
                //conn.Close(); <-- not needed.  using block handles this for you.
            }
        }
        return reader;
    }
