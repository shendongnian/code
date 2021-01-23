    public class GetDataResult
    {
        public GetDataResult(DataSet dataSet, string[] missingTables)
        {
            DataSet = dataSet;
            MissingTables = missingTables;
        }
        public string[] MissingTables { get; private set; }
        public DataSet DataSet { get; private set; }
    }
    private GetDataResult GetData(IEnumerable<string> tablesToFetch)
    {
        List<string> missingTables = new List<string>();
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
                missingTables.Add(tableName);
            }
        }
        return new GetDataResult(returnValue, missingTables.ToArray());
    }
