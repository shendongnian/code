    internal void InsertData(SqlConnection connection, Dictionary<int, int> valuesToInsert)
    {
    	using (DataTable myTvpTable = CreateDataTable(valuesToInsert))
    	using (SqlCommand cmd = connection.CreateCommand())
        {
    		cmd.CommandText = "INSERT INTO myTable SELECT RecordID, TagID FROM @myValues";
    		cmd.CommandType = CommandType.Text;
    		
    		SqlParameter parameter = cmd.Parameters.AddWithValue("@myValues", myTvpTable);
            parameter.SqlDbType = SqlDbType.Structured;
    		
    		cmd.ExecuteNonQuery();
    	}
    }
    
    private DataTable CreateDataTable(Dictionary<int, int> valuesToInsert)
    {
        // Initialize the DataTable
        DataTable myTvpTable = new DataTable();
    	myTvpTable.Columns.Add("RecordID", typeof(int));
    	myTvpTable.Columns.Add("TagID", typeof(int));
    	
    	// Populate DataTable with data
    	foreach(key in valuesToInsert.Key)
    	{
    		DataRow row = myTvpTable.NewRow();
    		row["RecordID"] = valuesToInsert[key];
    		row["TagID"] = key;
    	}
    }
