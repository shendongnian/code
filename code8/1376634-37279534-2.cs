    string ExcelFilename = "c:\\ExcelFile.xls";
    DataTable worksheets;
    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + ExcelFilename + ";" + @"Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        worksheets = connection.GetSchema("Tables");
        foreach (DataRow row in worksheets.Rows)
        {
        	// For Sheets: 0=Table_Catalog,1=Table_Schema,2=Table_Name,3=Table_Type
        	// For Columns: 0=Table_Name, 1=Column_Name, 2=Ordinal_Position
    	    string SheetName = (string)row[2];
    	    OleDbCommand command = new OleDbCommand(@"SELECT * FROM [" + SheetName + "]", connection);
    	    OleDbDataAdapter oleAdapter = new OleDbDataAdapter();
    	    oleAdapter.SelectCommand = command;
    	    DataTable dt = new DataTable();
    	    oleAdapter.FillSchema(dt, SchemaType.Source);
    	    oleAdapter.Fill(dt);
    	    for (int r = 0; r < dt.Rows.Count; r++)
    	    {
    	       string type1 = dr[1].GetType().ToString();
    	       string type2 = dr[2].GetType().ToString();
    	       string type3 = dr[3].GetType().ToString();
    	       string type4 = dr[4].GetType().ToString();
    	       string type5 = dr[5].GetType().ToString();
    	       string type6 = dr[6].GetType().ToString();
    	       string type7 = dr[7].GetType().ToString();
    	    }
        }
    }
