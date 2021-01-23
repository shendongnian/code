    int i = 0;
    int j = 0;
    _Workbook workbooksExcel;
    Worksheet worksheet;
    Excel._Application docExcel;
    //This will run a SQL Query and write results to DataSet
    SqlConnection conn;
    string sql = null;
    object misValue = System.Reflection.Missing.Value;
    docExcel = null;
    string ConnectionString = "Data Source=DS;Initial Catalog=TestDB;User ID = sa;Integrated Security=True;MultipleActiveResultSets=True";
    conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
    conn.Open();
    sql = "Insert SQL Statement Here";
    System.Data.SqlClient.SqlDataAdapter dscmd = new System.Data.SqlClient.SqlDataAdapter(sql, conn);
    ds = new DataSet();
    dscmd.Fill(ds);
    conn.Close();
    //Here is where the above SQL Statement will write to Excel
    for (i = 0; i <= SQLConnection.ds.Tables[0].Rows.Count - 1; i++)
    {
	  for (j = 0; j <= SQLConnection.ds.Tables[0].Columns.Count - 1; j++)
	  {
		try
		{
			data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
			_Workbook workbooksExcel = docExcel.ActiveWorkbook;
			Worksheet sheetExcel = (Worksheet)workbooksExcel.ActiveSheet;
			sheetExcel.Cells[i + 2, j + 1].Value = data;
		}
		catch (Exception ex) { } 
		}
    }
