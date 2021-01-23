            var connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            var selectQuery = "Select Id, FirstName, LastName, EmailAddress from RegisterInfoB";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();        
            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.Fill(dataSet, "RegisterInfoB");
            foreach (DataRow current in dataSet.Tables["RegisterInfoB"].Rows)
            {
                if (current["FirstName"].ToString().ToLower() == "praveen")
                {
                    var index = dataSet.Tables["RegisterInfoB"].Rows.IndexOf(current);
                    dataSet.Tables["RegisterInfoB"].Rows[index].Delete();
                }
            }
            var result = adapter.Update(dataSet.Tables["RegisterInfoB"]);
