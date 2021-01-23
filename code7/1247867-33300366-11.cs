    // PSEUDO!
    private DataTable GetTable(string tableName)
    {
        // if table isn't found return null
        if(<table is found>)
            return table;
        else
            return null;
    }
    private GetDataResult GetData(IEnumerable<string> tablesToFetch)
    {
        List<string> missingTables = new List<string>();
        DataSet returnValue = new DataSet();
        //TablesToFetch == string list or something containing tablenames you want to fetch
        foreach (string tableName in tablesToFetch)
        {
            var table = GetTable(tableName);
            if(table == null)
            {
                missingTables.Add(tableName);
                continue;
            }  
                
            // do something with the table.
        }
        return new GetDataResult(returnValue, missingTables.ToArray());
    }
