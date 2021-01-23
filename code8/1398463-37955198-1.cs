    public class SubscriptionHandlerFactory : ISubscriptionHandlerFactory
    {
        private readonly Lazy<IDependencyResolver> resolver;
        public SubscriptionHandlerFactory(Lazy<IDependencyResolver> resolver)
        {
            this.resolver = resolver;
        }
        public ISubscriptionHandler GetProvider(StreamType streamType)
        {
            switch (streamType)
            {
                case StreamType.Rss:
                    return (ISubscriptionHandler)this.resolver.Value.GetService(typeof(RssSubscriptionHandler));
                case StreamType.Person:
                    return (ISubscriptionHandler)this.resolver.Value.GetService(typeof(PersonSubscriptionHandler));
                default:
                    throw new ArgumentOutOfRangeException(nameof(streamType), streamType, null);
            }
        }
    }
