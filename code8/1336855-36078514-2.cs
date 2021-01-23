    string path = @"E:\USERS\MyWorkbook.xlsx";
    //Create connection string to Excel work book
    string excelConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
    
    OleDbConnection excelCon = new OleDbConnection(excelConString);
    
    excelCon.Open();
    
    DataTable dtsheet = new DataTable();
    
    dtsheet = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });    
    
    foreach (DataRow row in dtExcelSheet.Rows)
    { 
        Query = string.Format("Select * from [{0}]", row["TABLE_NAME"].ToString());
        //Create OleDbCommand to fetch data from Excel
        OleDbCommand cmd = new OleDbCommand(Query, excelCon);
        DataSet ds = new DataSet();
        OleDbDataAdapter oda = new OleDbDataAdapter(Query, excelCon);
        excelCon.Close();
        oda.Fill(ds);
        DataTable Exceldt = ds.Tables[0];
       foreach (DataRow dr in Exceldt.Rows)
       {
          //code to display
       }
    }
