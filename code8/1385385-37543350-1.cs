    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Test.xls;Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
    using (var conn = new OleDbConnection(sConnection)
    {
        conn.Open();
        string query = "SELECT  * FROM [" + mySheetName + "]";
        var adapter = new OleDbAdapter(query, conn);
        var table = new DataTable();
        adapter.Fill(table);
        //or you can use datareader
        //Now you can close excel and dbConnection
        //and work in memory with datatable and threads
    }
