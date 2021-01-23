    /// <summary>
    /// Provides methods for dispatching notifications to subscription handlers
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    public class ResultChangedMessage : IMessage<DateTime> where TContentType : class
    {
        public ResultChangedMessage(int changedResult)
        {
            this.Content = changedResult
        }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public int Content { get; protected set; }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public int GetContent()
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
