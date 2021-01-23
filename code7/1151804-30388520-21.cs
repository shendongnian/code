    using System;
    /// <summary>
    /// Handles chat message subscriptions
    /// </summary>
    internal class Notification<TMessage> : INotification<TMessage> where TMessage : class, IMessage
    {
        /// <summary>
        /// The callbacks invoked when the handler processes the messages.
        /// </summary>
        private Action<TMessage, ISubscription> callback;
        /// <summary>
        /// The conditions that must be met in order to fire the callbacks.
        /// </summary>
        private Func<TMessage, bool> condition;
        /// <summary>
        /// Occurs when the subscription is being unsubscribed.
        /// </summary>
        public event Action<NotificationArgs> Unsubscribing;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISubscription" /> is active.
        /// </summary>
        public bool IsActive { get; protected set; }
        /// <summary>
        /// Registers a callback for when a chat message is published by the MessageCenter
        /// </summary>
        /// <param name="processor">The message.</param>
        /// <returns></returns>
        public void Register(
            Action<TMessage, ISubscription> processor,
            Func<TMessage, bool> condition)
        {
            this.callback = processor;
            this.condition = condition;
            this.IsActive = true;
        }
        /// <summary>
        /// Unsubscribes the handler from notifications. This cleans up all of the callback references and conditions.
        /// </summary>
        public void Unsubscribe()
        {
            this.callback = null;
            this.condition = null;
            try
            {
                this.OnUnsubscribing();
            }
            finally
            {
                this.IsActive = false;
            }
        }
        /// <summary>
        /// Processes the message by verifying the callbacks can be invoked, then invoking them.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ProcessMessage(TMessage message)
        {
            if (this.condition != null && !this.condition(message))
            {
                this.callback(message, this);
                return;
            }
            this.callback(message, this);
        }
        /// <summary>
        /// Called when the notification is being unsubscribed from.
        /// </summary>
        protected virtual void OnUnsubscribing()
        {
            var handler = this.Unsubscribing;
            if (handler == null)
            {
                return;
            }
            handler(new NotificationArgs(this, typeof(TMessage)));
        }
    }
