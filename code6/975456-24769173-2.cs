    public string GetFirstSheet(string filePath)
    {
    	string connectionString = GetExcelConnectionString(filePath);
    
    	using (OleDbConnection connection = new OleDbConnection(connectionString))
    	{
    		connection.Open();
    		DataTable dtSheet = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    		return dtSheet.Rows[0]["TABLE_NAME"].ToString();
    	}
    
    	return String.Empty;
    }
