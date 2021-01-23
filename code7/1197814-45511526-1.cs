    public OleDbConnection myAccessConnection = new OleDbConnection();
    myAccessConnection.ConnectionString = 
    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\myAccessDb.accdb";
    OleDbCommand sqlCommand = new OleDbCommand();
    myAccessConnection.Open();
    sqlCommand.Connection = myAccessConnection;
    sqlCommand.CommandText = "ALTER TABLE [MyTableInMyAccessDb] ADD MyMemo MEMO";
    sqlCommand.ExecuteNonQuery();
    myAccessConnection.Close();
