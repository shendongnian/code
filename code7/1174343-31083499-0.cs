    string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sources.global_variables.db_source;
    using (OleDbConnection connection = new OleDbConnection(connString))
    {
        connection.Open();
        OleDbDataReader reader = null;
        string strQuery = "SELECT " + constStringColumnName1 + " FROM " + theTableNamePassedInAsString + " WHERE " + strWhereClauseBuiltEarlierInThisFunction + " = '@1'";
        OleDbCommand command = new OleDbCommand( strQuery , connection);
        command.Parameters.AddWithValue("@1", db_where_value);
        reader = command.ExecuteReader();
        //rest of code
    }
