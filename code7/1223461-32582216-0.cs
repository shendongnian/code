    using (SqlConnection connection = new SqlConnection(_ConnectionString))
    {
        connection.Open();
        using (SqlDataAdapter adapter = new SqlDataAdapter())
        {
            using (SqlCommand command = new SqlCommand())
            {
                using (SqlCommandBuilder builder = new SqlCommandBuilder())
                {
                    adapter.SelectCommand = command;// Command;
                    adapter.SelectCommand.Connection = connection;
                    builder.DataAdapter = adapter;
		            // here I let the command builder think that the table is myTable in stead of myView
                    adapter.SelectCommand.CommandText = "select * from myTable";
                    adapter.UpdateCommand = builder.GetUpdateCommand(true).Clone();
                    adapter.DeleteCommand = builder.GetDeleteCommand(true).Clone();
		            adapter.Update(Table);
                }
            }
        }
    }
