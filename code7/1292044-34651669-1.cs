    public class ServerConnectedEventArgs: EventArgs
    {
        public TcpClient Client { set; get; }
        public ServerConnectedEventArgs(TcpClient client)
        {
            Client = client;
        }
    }
    public delegate void ServerConnectedEventHandler(object sender, ServerConnectedEventArgs e);
