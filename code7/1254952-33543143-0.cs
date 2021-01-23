    // Create connection string variable. Modify the "Data Source"
    // parameter as appropriate for your environment.
    String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
    	"Data Source=" + Server.MapPath("../ExcelData.xls") + ";" +
    	"Extended Properties=Excel 8.0;";
    
    // Create connection object by using the preceding connection string.
    OleDbConnection objConn = new OleDbConnection(sConnectionString);
    
    // Open connection with the database.
    objConn.Open();
    
    // The code to follow uses a SQL SELECT command to display the data from the worksheet.
    
    // Create new OleDbCommand to return data from worksheet.
    OleDbCommand objCmdSelect =new OleDbCommand("SELECT * FROM myRange1", objConn);
    
    // Create new OleDbDataAdapter that is used to build a DataSet
    // based on the preceding SQL SELECT statement.
    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
    
    // Pass the Select command to the adapter.
    objAdapter1.SelectCommand = objCmdSelect;
    
    // Create new DataSet to hold information from the worksheet.
    DataSet objDataset1 = new DataSet();
    
    // Fill the DataSet with the information from the worksheet.
    objAdapter1.Fill(objDataset1, "XLData");
    
    // Bind data to DataGrid control.
    DataGrid1.DataSource = objDataset1.Tables[0].DefaultView;
    DataGrid1.DataBind();    
    
    // Clean up objects.
    objConn.Close();
