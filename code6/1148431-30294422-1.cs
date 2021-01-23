    /// <summary>
    /// Provides a server message to an event handler subscriber
    /// </summary>
    public class ServerMessageArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessageArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ServerMessageArgs(string message)
        {
            this.ServerMessage = message;
        }
        /// <summary>
        /// Gets the server message.
        /// </summary>
        public string ServerMessage { get; private set; }
    }
