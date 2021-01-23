    string commandText = "UPDATE Calls SET Service=Service + 1 WHERE Service = 3 OR Service = 5;";
    string connectionString = @"Data Source=
              (localdb)\Projects;Initial Catalog=FLS_DB;Integrated 
               Security=True;Connect Timeout=30;Encrypt=False;";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {            
            SqlCommand command = new SqlCommand(commandText, connection);            
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
