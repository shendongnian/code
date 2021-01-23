    var currentLogTime = DateTime.UtcNow.ToString("yyMMddHH");
    protected const string FORMAT_CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBASE IV";
    var connectionString = String.Format(FORMAT_CONNECTION_STRING, DBFPath);
    Source="yourFilePathToSourceFile";Extended Properties=dBase IV";
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = String.Format("CREATE TABLE {0} (SEVERITY I, MESSAGE M, STACKTRACE M, OCCURRED C(50) NOCPTRANS"
        command.ExecuteNonQuery();
    }
