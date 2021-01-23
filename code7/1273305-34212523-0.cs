    public static void CopyTable(
      string databaseName,   // i.e. Northwind
      string tableName,      // i.e. Employees
      string schema1,        // i.e. dbo
      string schema2,        // i.e. dboarchive
      SqlConnection sqlConn)
    {
        var conn = new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConn);
        var server = new Microsoft.SqlServer.Management.Smo.Server(conn);
        var db = new Microsoft.SqlServer.Management.Smo.Database(server, databaseName);
        for (var itemId = 0; itemId < db.Tables.Count; itemId++)
        {
            var table = db.Tables.ItemById(itemId);
            if (table.Name == tableName)
            {
                table.Schema = String.Format("{0}", DatabaseSchema.dboarchive);
                table.Create();
            }
        }
    }
