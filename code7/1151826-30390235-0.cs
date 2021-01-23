    string connectionString = 
        @"Provider=Microsoft.Jet.OLEDB.4.0;" +
        @"Data Source="Path of you hosting provider database";" +
        @"User Id= "hosting db user id];Password=[hosting db password";";
    
    string queryString = "SELECT Foo FROM Bar";
    
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = new OleDbCommand(queryString, connection))
    {
        try
        {
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
    
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
