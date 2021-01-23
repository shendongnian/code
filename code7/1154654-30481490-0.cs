    public static int mysql_query_scalar(string Command, SqlParameter[] parameters)
    {
        using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
        {
            myConnection.Open();
            using (MySqlCommand myCommand = new MySqlCommand(Command, myConnection))
            {
                myCommand.Parameters.AddRange(parameters); // Add Parameters here
                return (int)myCommand.ExecuteScalar();
            }
        }
    }
