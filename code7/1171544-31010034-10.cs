    /// <summary>
    /// Allows for receiving the content of a message
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns>Returns the content of the message</returns>
        object GetContent();
    }
    /// <summary>
    /// Allows for receiving the content of a message
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    public interface IMessage<TContent> : IMessage where TContent : class
    {
        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        TContent Content { get; }
    }
