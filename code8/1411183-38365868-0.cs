    private static List<string> ReadTableColumns(string connectionString)
    {
        List<string> columnNames = new List<string>();
        string queryString = 
            "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
          + "WHERE TABLE_NAME = 'YourTableNameHere'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(
                queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    columnNames.Add(reader[0].ToString());
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }
    
        return ColumnNames;
    }
    
    
    listBox1.Datasource = ReadTableColumns(yourConnectionString);
