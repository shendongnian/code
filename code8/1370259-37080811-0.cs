    public struct ServerList
    {
        public string ServerName { get; private set; }
        public string ServerReboot { get; private set; }
        public string ServerShutdown { get; private set; }
    
        public ServerList(string name, string reboot, string shutDown)
        {
            this.ServerName = name;
            this.ServerReboot = reboot;
            this.ServerShutdown = shutDown;
        }
    }
