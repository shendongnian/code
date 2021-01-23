    class ServerManager
    {
        private static readonly ServerManager _instance = new ServerManager();
        private readonly Dictionary<Int32, ChatServer> _servers;
    
        private ServerManager()
        {
    		_servers = new Dictionary<int, ChatServer>();
            _servers.Add(1, new ChatServer());
            _servers.Add(2, new ChatServer());
            _servers.Add(3, new ChatServer());
        }
    
        public static ServerManager Instance
        {
            get { return _instance; }
        }
    
        public void AddMessage(Int32 serverID, String message)
        {
            _servers[serverID].AddMessage(message);
        }
    
        public List<String> GetNewMessages(Int32 serverID)
        {
            return _servers[serverID].GetNewMessages();
        }
    }
