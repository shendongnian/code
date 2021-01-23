    string filePath = @"<FilePath>";
    string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0, Data Source={0}"; 
    OleDbConnection conn = new OleDbConnection();
    OleDbCommand cmd = new OleDbCommand();
    conn.ConnectionString = string.Format(connectionString, filePath);
    conn.Open();
    cmd.CommandText = "Insert into [Sheet1$] (a1,a2) values('5','e')";
    cmd.ExecuteNonQuery();
    conn.Close();
 
