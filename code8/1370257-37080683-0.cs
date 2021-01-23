    public class ServerList
    {
        // properties...
        // ctor...
    
        public ServerList Clone()
        {
            return new ServerList
            {
                ServerName = ServerName,
                ServerReboot = ServerReboot,
                ServerShutdown = ServerShutdown,
            });
        }
    }
