    string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                               "Data Source=e:\\Test.xlsx;Mode=ReadWrite;" +
                               "Extended Properties=\"Excel 12.0;HDR=Yes\"";
    OleDbConnection oConnection = new OleDbConnection();
    oConnection.ConnectionString = sConnectionString;
    oConnection.Open();
