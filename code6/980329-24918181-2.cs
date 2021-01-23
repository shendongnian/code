    public interface IMessagePublisher<TEventArgs> where TEventArgs : EventArgs
    {
        event EventHandler<TEventArgs> MessageReceived;
    }
    public class MessageRePublisher<TEventArgs> : IMessagePublisher<TEventArgs>, IDisposable where TEventArgs : EventArgs
    {
        readonly IMessagePublisher<TEventArgs> publisher;
        public MessageRePublisher(IMessagePublisher<TEventArgs> publisher)
        {
            this.publisher = publisher;
        }
        EventHandler<TEventArgs> messageReceivedEventsAdded = null;
        public event EventHandler<TEventArgs> MessageReceived 
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add 
            {
                // events are multicast delegates, which are immutable.  We need to remove the previous
                // combined event, create a new combined event, then added that.
                // More here: http://msdn.microsoft.com/en-us/magazine/cc163533.aspx
                if (messageReceivedEventsAdded != null)
                    publisher.MessageReceived -= messageReceivedEventsAdded;
                messageReceivedEventsAdded += value;
                if (messageReceivedEventsAdded != null)
                    publisher.MessageReceived += messageReceivedEventsAdded;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove 
            {
                if (messageReceivedEventsAdded != null)
                    publisher.MessageReceived -= messageReceivedEventsAdded;
                messageReceivedEventsAdded -= value;
                if (messageReceivedEventsAdded != null)
                    publisher.MessageReceived += messageReceivedEventsAdded;
            }
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (messageReceivedEventsAdded != null && publisher != null)
                {
                    publisher.MessageReceived -= messageReceivedEventsAdded;
                }
            }
            messageReceivedEventsAdded = null;
        }
        #endregion
    }
