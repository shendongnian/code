    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
    
        adapter.SelectCommand = new SqlCommand(queryString, connection);
        adapter.InsertCommand = builder.GetInsertCommand();
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.DeleteCommand = builder.GetDeleteCommand();
    
        DataTable dt = new DataTable();
        adapter.Fill(dt);
    
        DataRow row = dt.NewRow();
        row["RegionID"] = 5;
        row["RegionDescription"] = "Some region";
        dt.Rows.Add(row);
    
        //dt.AcceptChanges();
    
        int counter = adapter.Update(dt); 
    }                    
