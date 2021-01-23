    public class ConnectedArgs : EventArgs
    {
        /// <summary>
        /// Instances a new ConnectedArgs class.
        /// </summary>
        /// <param name="state">The state of a client connection.</param>
        public ConnectedArgs(ConnectionState state)
        {
            this.ConnectedClient = state;
        }
        /// <summary>
        /// Gets the client currently connected.
        /// </summary>
        public ConnectionState ConnectedClient { get; private set; }
    }
