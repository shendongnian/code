    string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=Excel 12.0;", "myDocument.xlsx");
    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM MyTable", connString);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "TheData");
    DataTable theTable = ds.Tables["TheData"];
