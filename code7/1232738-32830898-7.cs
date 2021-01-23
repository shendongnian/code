            var connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            var selectQuery = "Select * from RegisterInfoB";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();        
            // you can use the builder to generate the DeleteCommand
            adapter.DeleteCommand = builder.GetDeleteCommand();
            // or 
            // adapter.DeleteCommand = new SqlCommand("DELETE FROM RegisterInfoB WHERE FirstName = @FirstName", connection);
    
            adapter.Fill(dataSet, "RegisterInfoB");
            // you can use the foreach loop 
    
            foreach (DataRow current in dataSet.Tables["RegisterInfoB"].Rows)
            {
                if (current["FirstName"].ToString().ToLower() == "praveen")
                {
                    var index = dataSet.Tables["RegisterInfoB"].Rows.IndexOf(current);
                    dataSet.Tables["RegisterInfoB"].Rows[index].Delete();
                }
            }
            // or the linq expression 
            // dataSet.Tables["RegisterInfoB"]
            //    .AsEnumerable()
            //    .Where(dr => dr["FirstName"].ToString().ToLower().Trim() == "praveen")
            //    .ToList()
            //    .ForEach((dr)=> dr.Delete());
    
            var result = adapter.Update(dataSet.Tables["RegisterInfoB"]);
