            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string selectQuery = "Select Id, FirstName, LastName, EmailAddress from RegisterInfoB";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();
            List<DataRow> rowsToDelete = new List<DataRow>();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();  
            adapter.Fill(dataSet, "RegisterInfoB");
            foreach (DataRow current in dataSet.Tables[0].Rows)
            {
                if (current["FirstName"].ToString().ToLower() == "praveen")
                    rowsToDelete.Add(current);
            }
            foreach (var current in rowsToDelete)
            {
                dataSet.Tables[0].Rows.Remove(current);
            }
            var result = adapter.Update(dataSet, "RegisterInfoB");
