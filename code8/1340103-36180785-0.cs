    DataTable dataTable = new DataTable();  
    using (var conn1 = new OleDbConnection(@"ConnectionString"))
    using (var cmd = new OleDbCommand(sqlstring, conn1))
    {
        conn1.Open();
        dataTable.Load(cmd.ExecuteReader());
    }
    foreach(DataRow row in dataTable.Rows)
    {
        MessageBox.Show(row["SerialNumber"].ToString());
    }
