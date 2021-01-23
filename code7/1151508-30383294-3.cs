    namespace Eventing
    {
        public class EventAggregator : IEventAggregator
        {
            private readonly Dictionary<Type, List<WeakReference>> eventSubscriberLists =
                new Dictionary<Type, List<WeakReference>>();
            private readonly object padLock = new object();
    
            public void Subscribe(object subscriber)
            {
                Type type = subscriber.GetType();
                var subscriberTypes = GetSubscriberInterfaces(type)
                    .ToArray();
                if (!subscriberTypes.Any())
                {
                    throw new ArgumentException("subscriber doesn't implement ISubscriber<>");
                }
    
                lock (padLock)
                {
                    var weakReference = new WeakReference(subscriber);
                    foreach (var subscriberType in subscriberTypes)
                    {
                        var subscribers = GetSubscribers(subscriberType);
                        subscribers.Add(weakReference);
                    }
                }
            }
    
            public void Unsubscribe(object subscriber)
            {
                Type type = subscriber.GetType();
                var subscriberTypes = GetSubscriberInterfaces(type);
    
                lock (padLock)
                {
                    foreach (var subscriberType in subscriberTypes)
                    {
                        var subscribers = GetSubscribers(subscriberType);
                        subscribers.RemoveAll(x => x.IsAlive && object.ReferenceEquals(x.Target, subscriber));
                    }
                }
            }
    
            public void Publish<TEvent>(TEvent eventToPublish)
            {
                var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
                var subscribers = GetSubscribers(subscriberType);
                List<WeakReference> subscribersToRemove = new List<WeakReference>();
    
                WeakReference[] subscribersArray;
                lock (padLock)
                {
                    subscribersArray = subscribers.ToArray();
                }
    
                foreach (var weakSubscriber in subscribersArray)
                {
                    ISubscriber<TEvent> subscriber = (ISubscriber<TEvent>)weakSubscriber.Target;
                    if (subscriber != null)
                    {
                        subscriber.OnEvent(eventToPublish);
                    }
                    else
                    {
                        subscribersToRemove.Add(weakSubscriber);
                    }
                }
                if (subscribersToRemove.Any())
                {
                    lock (padLock)
                    {
                        foreach (var remove in subscribersToRemove)
                            subscribers.Remove(remove);
                    }
                }
            }
    
            private List<WeakReference> GetSubscribers(Type subscriberType)
            {
                List<WeakReference> subscribers;
                lock (padLock)
                {
                    var found = eventSubscriberLists.TryGetValue(subscriberType, out subscribers);
                    if (!found)
                    {
                        subscribers = new List<WeakReference>();
                        eventSubscriberLists.Add(subscriberType, subscribers);
                    }
                }
                return subscribers;
            }
    
            private IEnumerable<Type> GetSubscriberInterfaces(Type subscriberType)
            {
                return subscriberType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(ISubscriber<>));
            }
        }
    
        public interface IEventAggregator
        {
            void Subscribe(object subscriber);
            void Unsubscribe(object subscriber);
            void Publish<TEvent>(TEvent eventToPublish);
        }
    
        public interface ISubscriber<in T>
        {
            void OnEvent(T e);
        }
    }
