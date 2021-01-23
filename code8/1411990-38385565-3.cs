    using(var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using(var command = new connection.CreateCommand())
        {
            command.CommandText = "--Some Awesome Sql Here";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@awesomeVariable",1337);
            
            /* Do Stuff until you need to make a new query / request */
            
            command.CommandText = "StoredProcedureGuy";
            //Get rid of old parameters
            command.Parameters.Clear();
            
            /* Rinse repeat */
        }
    }
