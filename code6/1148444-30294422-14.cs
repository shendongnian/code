    public class ServerMessageArgs : EventArgs
    {
        public ServerMessageArgs(string message)
        {
            this.ServerMessage = message;
        }
        public string ServerMessage { get; private set; }
    }
