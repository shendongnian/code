    public sealed class NetClient
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public Headers Headers { get; private set; }
    
        public NetClient(string host, int port)
        {
            Host = host;
            Port = port;
    
            Headers = new Headers();
        }
    }
    
    public sealed class Headers : Dictionary<String, String>
    {
    }
