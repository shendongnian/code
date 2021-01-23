    string SearchQuery = @"if exists (select * from table where colName = @colNameVal) select 1 else select 0";
    AseConnection connection = new AseConnection();
    connection.ConnectionString = connectionString;
    connection.Open();
    try
    {
        AseCommand selectCommand = new AseCommand(SearchQuery, connection);
    	AseParameter parm = new AseParameter("@colNameVal", AseDbType.NVarChar, 13);
    	parm.Value = "123";
    
        selectCommand.Parameters.Add(parm);
        int doesValExist = (int)selectCommand.ExecuteScalar();
    }
    catch(Exception ex)
    {
    
    }
