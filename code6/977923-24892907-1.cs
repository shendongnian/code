    public class ConnectionInfo
    {
        public string ConnectionString { get; private set; }
    
        private ConnectionInfo()
        {
            var connectionstring = string.Empty;
            //some logic
    
            this.ConnectionString = connectionstring;
        }
    
        private static ConnectionInfo current;
    
        public static ConnectionInfo Current {
            get {
                if (current != null)
                    current = new ConnectionInfo();
    
                return current;
            }
        }
    }        
    [OperationContract]
    public IEnumerable<Encountertime> GetEncounterTimes(DateTime? encountertime)
    {
        using (var context = new ChaosModel(ConnectionInfo.Current.ConnectionString))
        {
           ...
        }
    }
