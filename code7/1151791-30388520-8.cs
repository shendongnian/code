    /// <summary>
    /// Provides methods for dispatching notifications to subscription handlers
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    public class StartMyTvNotification : IMessage<bool> where TContentType : class
    {
        public StartMyTvNotification(bool isOn)
        {
            this.Content = isOn;
        }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public bool Content { get; protected set; }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public bool GetContent()
        {
            return this.Content;
        }
        /// <summary>
        /// Gets the content.
        /// </summary>
        object IMessage.GetContent()
        {
            return this.GetContent();
        }
    }
