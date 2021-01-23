    public class ConnectedArgs : EventArgs
    {
        public ConnectedArgs(ConnectionState state)
        {
            this.ConnectedClient = state;
        }
        public ConnectionState ConnectedClient { get; private set; }
    }
