    public List<DataTable> RunStoredProc(string databaseConnection)
    {
        var dataTables = new List<DataTable>();  
        DSqlQueryBuilder = new StringBuilder();
        SqlQueryBuilder.Append("exec dbo.StoredProc "); 
        SqlConnection = new SqlConnection(connectionString);
        SqlCommand = new SqlCommand(sqlQuery, SqlConnection);
        var reader = SqlCommand.ExecuteReader();
        var dt1 = new DataTable().Load(reader);
        dataTables.Add(dt1);
        reader.NextResult();
        var dt2 = new DataTable().Load(reader);
        dataTables.Add(dt1);
        // Make sure to really use usings here to ensure all resources are being 
    closed
        return dataTables;
    }
