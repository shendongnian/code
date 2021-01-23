    static void Main(string[] args)
    {
        string accessConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Temp\\StackOverflowDemo\\MyAccessDb.mdb;User Id=admin;Password =; ";
        using (DbConnection accessConnection = new OleDbConnection(accessConnectionString))
        {
            accessConnection.Open();
            using (DbCommand accessCommand = new OleDbCommand())
            {
                string accessQuery =
                    "SELECT * INTO [MySqlTable] IN '' [ODBC;Driver={SQL Server};Server=(local);Database=MySqlDb;Uid=username;Pwd=password;] FROM [MyAccessTable]";
                accessCommand.CommandText = accessQuery;
                accessCommand.Connection = accessConnection;
                accessCommand.ExecuteNonQuery();
            }
        }
    }
