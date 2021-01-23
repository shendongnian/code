    private void SetDataSource
       (string conn, string query, DataSet dataSet)
    {
       OleDbConnection oleConn = new OleDbConnection(conn);
       OleDbDataAdapter oleAdapter = new OleDbDataAdapter();
       oleAdapter.SelectCommand = new OleDbCommand(query, oleConn);
    
       oleAdapter.Fill(dataSet, "Customer");
    
       reportDocument.Database.Tables["Customer"].SetDataSource (dataSet);
    }
