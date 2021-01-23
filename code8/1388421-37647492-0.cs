    string commandText = "UPDATE Calls SET Service=@Service;";
    string connectionString = @"Data Source=
              (localdb)\Projects;Initial Catalog=FLS_DB;Integrated 
               Security=True;Connect Timeout=30;Encrypt=False;";
    foreach (int i in Status)
    {        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int newValue = i;
            if (i == 3 || i == 5) { newValue = i+1; }
            else { continue; }
            
            SqlCommand command = new SqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@Service", newValue);
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
    }
