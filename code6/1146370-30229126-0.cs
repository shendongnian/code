     string connectionString = "Data Source=localhost\\SqlExpress;Initial Catalog=MMABooks;Integrated Security=True";
     SqlConnection connection = new SqlConnection(connectionString);
    
     string selectStatement = "SELECT ProductCode FROM Products WHERE ProductCode = @ProductCode";
     SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
    
     selectCommand.Parameters.AddWithValue("@ProductCode", "XYZ");//Or whatever your parameter value is
     connection.Open();
    
     SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
    
     reader.Read();
    
     txtDisplay.Text = reader["ProductCode"].ToString();
    
     reader.Close();
    
     connection.Close();
