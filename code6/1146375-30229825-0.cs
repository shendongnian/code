     string connectionString = "Data Source=localhost\\SqlExpress;Initial Catalog=MMABooks;" + "Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            
            string selectStatement = "SELECT ProductCode " + "FROM Products " + "WHERE ProductCode = @ProductCode";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            string code = "DB1R";
            selectCommand.Parameters.AddWithValue("@ProductCode", code);  //productcode points to the column, and code points the row
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            reader.Read();
            txtDisplay.Text = reader["ProductCode"].ToString();
            connection.Close();
