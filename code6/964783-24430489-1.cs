        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand
                   ("SELECT TOP 10 Name, [Description] FROM Business; SELECT TOP 10 ConnectionId FROM Connection;SELECT TOP 10 Name FROM Business", connection))
            {
                connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet(); 
                    adapter.SelectCommand = command;
                    //Note here, that the adapter will create multiple tables for each result set
                    adapter.Fill(set); 
                    
                    foreach (DataTable t in set.Tables)
                    {
                        dataTables.Add(t);
                    }
                    dataTables.Add(tempTable);
            }
        } 
