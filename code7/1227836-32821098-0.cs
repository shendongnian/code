    Stopwatch s = new Stopwatch();
    s.Start();
    string sSheetName = null;
    string sConnection = null;
    System.Data.DataTable sheetData = new System.Data.DataTable();
    System.Data.DataTable dtTablesList = default(System.Data.DataTable);
    OleDbConnection oleExcelConnection = default(OleDbConnection);
    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\YOURUSERNAME\Documents\Visual Studio 2012\Projects\TestXmlParser\TestXmlParser\bin\Debug\ConsolidatedSSMFiles.xlsx" + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
    oleExcelConnection = new OleDbConnection(sConnection);
    oleExcelConnection.Open();
    dtTablesList = oleExcelConnection.GetSchema("Tables");
    if (dtTablesList.Rows.Count > 0)
    {
    sSheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
    }
    dtTablesList.Clear();
    dtTablesList.Dispose();
    
    if (!string.IsNullOrEmpty(sSheetName))
    {
    OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [TEST$]", oleExcelConnection);
    sheetAdapter.Fill(sheetData);
    } s.Stop();
    var duration = s.Elapsed;
    
             
    oleExcelConnection.Close();
    dataGridView1.DataSource = sheetData;
    MessageBox.Show(sheetData.Rows.Count.ToString()+"rows - "+ duration.ToString());
