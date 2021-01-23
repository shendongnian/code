    public class Server:BaseObservableObject
    {
        private string _serverName;
        private string _players;
        private string _map;
        private string _gameType;
        private string _ip;
        public string ServerName
        {
            get { return _serverName; }
            set
            {
                _serverName = value;
                OnPropertyChanged();
            }
        }
        public string Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }
        public string Map
        {
            get { return _map; }
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }
        public string GameType
        {
            get { return _gameType; }
            set
            {
                _gameType = value;
                OnPropertyChanged();
            }
        }
        public string Ip
        {
            get { return _ip; }
            set
            {
                _ip = value;
                OnPropertyChanged();
            }
        }
    }
