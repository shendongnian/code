    private static void ReadOrderData(string connectionString)
    {
        string queryString =
            "SELECT OrderID, CustomerID FROM dbo.Orders;";
    
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();
    
            SqlDataReader reader = command.ExecuteReader();
    
            // Call Read before accessing data. 
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }
    
            // Call Close when done reading.
            reader.Close();
        }
    }
