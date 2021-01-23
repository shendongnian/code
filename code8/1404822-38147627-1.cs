    static bool FireCommand(SqlCommand command)
    {
        command.Connection.Open();
        command.ExecuteQuery();
        command.Connection.Close();
     }
        
