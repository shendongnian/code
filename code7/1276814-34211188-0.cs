    public List<DataSet> RunStoredProc(string databaseConnection)
    {
        var dataSets = new List<DataSet>();  
        DSqlQueryBuilder = new StringBuilder();
        SqlQueryBuilder.Append("exec dbo.StoredProc "); 
        SqlConnection = new SqlConnection(connectionString);
        SqlCommand = new SqlCommand(sqlQuery, SqlConnection);
        var reader = SqlCommand.ExecuteReader();
        var ds1 = new DataSet().Load(reader);
        dataSets.Add(ds1);
        reader.NextResult();
        var ds2 = new DataSet().Load(reader);
        dataSets.Add(ds1);
        // Make sure to really use usings here to ensure all resources are being 
    closed
        return dataSets;
    }
