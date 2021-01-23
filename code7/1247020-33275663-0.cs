    string pass = string.Empty;
    using (var sqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection | CommandBehavior.SingleRow))
    {
         if(sqlDataReader.Read())
         {
             pass = sqlDataReader.GetString(0);
         }
    }
