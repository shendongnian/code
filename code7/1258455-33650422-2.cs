        public class ServerDetails:BaseObservableObject
    {
        private string _serverName;
        public string ServerName
        {
            get { return _serverName; }
            set
            {
                _serverName = value;
                OnPropertyChanged();
            }
        }
        public List<DbDetails> DbDetailses { get; set; }
    }
    public class DbDetails:BaseObservableObject
    {
        private string _dbName;
        public string DbName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                OnPropertyChanged();
            }
        }
    }
