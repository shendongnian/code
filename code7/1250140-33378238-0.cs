    public async Task Submit() 
    {
        int[] ids = new[] { 1, 2, 3, 4, 5 };
        var sqlList = new List<sqlData>();
        sqlList.Add(await Task.WhenAll(ids.Select(i => GetSqlData(i, DateTime.Now.ToString(), 0, 1))));
    }
    public async Task<List<sqlData>> GetSqlData(int dataType, string dateTime, int getLatest, int getArchived)
    {
        var sqldata = new List<sqlData>();
        //Populate retValue
        return sqldata;
    }
