    public MySqlReader(MySqlCommand command)
    {
        //HERE!!!!
    	command.CommandTimeout = 60;
    
        if (command.Type == MySqlCommandType.SELECT)
        {
             _dataset = new DataSet();
             _row = 0;
             using (MySql.Data.MySqlClient.MySqlConnection conn = 
                 DataHolder.MySqlConnection)
             {
                 conn.Open();
                 using (var DataAdapter = new MySqlDataAdapter(command.Command, conn))
                      DataAdapter.Fill(_dataset, Table);
                     ((IDisposable)command).Dispose();  // in this line
            }
        }
    }
