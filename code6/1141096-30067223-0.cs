    DataTable dataTable = new DataTable("USERMASTER");  
    using (var conn = new OleDbConnection(sConnectionString))
    {
    	conn.Open();
    	var queryString = "SELECT * FROM USERMASTER";
    	using (var comm = new OleDbCommand(queryString, conn))
    	{
    		using (OleDbDataAdapter da = new OleDbDataAdapter (comm))
    		{
    			da.Fill(dataTable);
    			return dataTable;
    		}
    	}
        conn.Close();
    }
