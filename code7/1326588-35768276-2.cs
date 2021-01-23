    string SearchQuery = @"select count(*) from table where colName = @colNameVal";
    AseConnection connection = new AseConnection();
    connection.ConnectionString = connectionString;
    connection.Open();
    try
    {
        AseCommand selectCommand = new AseCommand(SearchQuery, connection);
        selectCommand.Parameters.Add(new AseParameter("@colNameVal", AseDbType.NVarChar, 13)).Value = "123";
        int doesValExist = (int)selectCommand.ExecuteScalar();
    }
    catch(Exception ex)
    {
    
    }
