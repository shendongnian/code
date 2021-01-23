    public abstract class Publisher<T> : IPublisher<T>
    {
        protected readonly object InstanceLock = new object();
        protected List<ISubscriber<T>> Subscribers = new List<ISubscriber<T>>();
        public virtual void Subscribe(ISubscriber<T> subscriber)
        {
            lock (InstanceLock)
            {
                var newSubscribers = Subscribers.ToList();
                if (!newSubscribers.Contains(subscriber))
                {
                    newSubscribers.Add(subscriber);
                    Subscribers = newSubscribers;
                }
            }
        }
        public virtual void Unsubscribe(ISubscriber<T> subscriber)
        {
            lock (InstanceLock)
            {
                var newSubscribers = Subscribers.ToList();
                if (newSubscribers.Contains(subscriber))
                {
                    newSubscribers.Remove(subscriber);
                    Subscribers = newSubscribers;
                }
            }
        }
        public virtual bool IsSubscribed(ISubscriber<T> subscriber)
        {
            lock (InstanceLock)
            {
                return Subscribers.Contains(subscriber);
            }
        }
        public virtual void Publish(T value)
        {
            var subscribers = Subscribers;
            for (int i = 0; i < subscribers.Count; i++) subscribers[i].Record(value);
        }
    }
