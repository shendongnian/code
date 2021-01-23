    public class Server
    {
        public string Name { get; set; }
        public bool Connected { get; set; }
        public string ConnectionStatus
        {
            get { return Connected ? "Connected" : "Disconnected"; }
        }
    }
