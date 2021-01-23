    using System;
    /// <summary>
    /// Processes a subscription message.
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    public interface INotification<TMessageType> : ISubscription where TMessageType : class, IMessage
    {
        /// <summary>
        /// Registers the specified action for callback when a notification is fired for T.
        /// </summary>
        /// <param name="callback">The message being posted along with the subscription registered to receive the post.</param>
        /// <returns></returns>
        void Register(
            Action<TMessageType, ISubscription> callback,
            Func<TMessageType, bool> condition = null);
        /// <summary>
        /// Processes the message, invoking the registered callbacks if their conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        void ProcessMessage(TMessageType message);
    }
