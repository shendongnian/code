    //call the method this way
    var someDataTable = ExecuteDataSet("SELECT * FROM [Sheet1$]", InputFile);
    public static DataTable ExecuteDataSet(string sql, string InputFile)
    {
    	using (DataSet myDataset = new DataSet())
    	using (OleDbConnection OleDBconn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Macro;HDR=Yes;IMEX=1\"",InputFile));
    	using (OleDbCommand cmdSelect = new OleDbCommand(sql, OleDBconn))
    	{
    		try
    		{
    			OleDBconn.Open();
                dtXLS = OleDBconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);//if you need to return this change the method signature to out param for this
    			new OleDbDataAdapter(cmdSelect).Fill(myDataset);
    		}
    		catch (Exception ex)
    		{
    			//Show a message or log a message on ex.Message
    		}
    		return myDataset.Tables[0];
    	}
    }	
