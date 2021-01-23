    public class NotificationArgs
    {
        public NotificationArgs(ISubscription subscription, Type messageType)
        {
            this.Subscription = subscription;
            this.MessageType = messageType;
        }
        public ISubscription Subscription { get; private set; }
        public Type MessageType { get; private set; }
    }
