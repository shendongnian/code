    /// <summary>
    /// Provides a contract to Types wanting to subscribe to published messages 
    /// with conditions and a callback.
    /// </summary>
    public interface ISubscription
    {
        /// <summary>
        /// Occurs when the subscription is being unsubscribed.
        /// </summary>
        event Action<NotificationArgs> Unsubscribing;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISubscription"/> is active.
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Unsubscribes the registerd callbacks from receiving notifications.
        /// </summary>
        /// <param name="notificationCenter">The notification center.</param>
        void Unsubscribe();
    }
