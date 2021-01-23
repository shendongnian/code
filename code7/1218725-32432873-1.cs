    public class FileOperation 
    {
        public ILogger Log { get; set; }
        public IDataConnector DataConnector { get; set; }
        public FileOperation()
            : this(new Logger(), new DataConnector<string>())
        {
        }
        public FileOperation(ILogger log, IDataConnector dataConnector) {
            Log = log;
            DataConnector = dataConnector;
        }
    }
