    IEnumerable<IDictionary<string, object>> result;
    
    using (var cnn = new SqlConnection(connectionString))
    {
        cnn.Open();
        
        var p = new DynamicParameters();
        p.Add(" @fromDate", fromDate, DbType.DateTime);
        p.Add(" @toDate", toDate, DbType.DateTime);
        
        result = (IEnumerable<IDictionary<string, object>>)
                    cnn.Query(sql: "getMonthIsin", 
                              param: p, 
                              commandType: CommandType.StoredProcedure);
    }
