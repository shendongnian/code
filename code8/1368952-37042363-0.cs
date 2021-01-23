    public void UpdateEarlyStageData(string filePath, OleDbCommand queryCommand)
    {
        //Connection string initializer
        using (OleDbConnection connection = new OleDbConnection("connectionString"))
        {
            queryCommand.Connection = connection;
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryCommand))
            {
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                // assignment operations
            }
        }
    }
 
      
