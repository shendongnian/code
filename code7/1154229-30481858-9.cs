    interface IDataFetcher
    {
     object getData();
    }
    
    class FileFetcher : IDataFetcher
    {
     private string _filePath;
     public FileFetcher(IRuntimeData userInputData)
     {
      _filePath = userInputData.filePath;
     }
    
     public object getData()
     {
      return "Hello from FileFetcher. File path is " + _filePath;
     }
    }
    
    class DBFetcher : IDataFetcher
    {
     private string _connStr;
     public DBFetcher(IRuntimeData userInputData)
     {
      _connStr = userInputData.connectionString;
     }
    
     public object getData()
     {
      return "Hello from DBFetcher. Connection string is " + _connStr;
     }
    }
    
    class MachineFetcher : IDataFetcher
    {
     private string _machineName;
     public MachineFetcher(IRuntimeData userInputData)
     {
      _machineName = userInputData.machineName;
     }
    
     public object getData()
     {
      return "Hello from MachineFetcher. Machine name is " + _machineName;
     }
    }
