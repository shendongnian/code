    private DataSet GetData(IEnumerable<string> tablesToFetch)
    {
        var exceptions = new List<Exception>();
        DataSet returnValue = new DataSet();
        //TablesToFetch == string list or something containing tablenames you want to fetch
        foreach (string tableName in tablesToFetch)
        {
            try
            {
                //get table tableName and add it to returnValue
            }
            catch (ArgumentException e)
            {
                //handle exception
                exceptions.Add(e);
            }
        }
        if (exceptions.Count > 0)
            throw new AggregateException(exceptions);
        return returnValue;
    }
