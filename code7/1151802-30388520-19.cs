    /// <summary>
    /// Provides methods for dispatching notifications to subscription handlers
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    public class WakeMeUpNotification : IMessage<DateTime> where TContentType : class
    {
        public WakeMeUpNotification(DateTime timeToWakeUp)
        {
            this.Content = timeToWakeUp
        }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public DateTime Content { get; protected set; }
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public DateTime GetContent()
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
