    public enum HandlerThreadOption
    {
        PublisherThread,
        SubscriberThread,
        BackgroundThread
    }
    public class EventSubscriptionToken : IDisposable
    {
        private readonly Action _unsubscribe;
    
    
        public EventSubscriptionToken(Action unsubscribe)
        {
            _unsubscribe = unsubscribe;
        }
    
    
        public void Unsubscribe()
        {
            _unsubscribe();
        }
    
    
        void IDisposable.Dispose()
        {
            Unsubscribe();
        }
    }
    public static class EventSubscription
    {
        public static EventSubscriptionToken FromEvent<TEventArgs>(
            Action<EventHandler<TEventArgs>> addHandler,
            Action<EventHandler<TEventArgs>> removeHandler,
            EventHandler<TEventArgs> handler,
            HandlerThreadOption threadOption)
        {
            var threadSpecificHandler = GetHandler(handler, threadOption);
            addHandler(threadSpecificHandler);
    
            return new EventSubscriptionToken(() => removeHandler(threadSpecificHandler));
        }
    
        public static EventSubscriptionToken FromEvent(
            Action<EventHandler> addHandler,
            Action<EventHandler> removeHandler,
            EventHandler handler,
            HandlerThreadOption threadOption)
        {
            var threadSpecificHandler = GetHandler(handler, threadOption);
            addHandler(threadSpecificHandler);
    
            return new EventSubscriptionToken(() => removeHandler(threadSpecificHandler));
        }
    
    
        private static EventHandler<T> GetHandler<T>(EventHandler<T> handler, HandlerThreadOption threadOption)
        {
            switch (threadOption)
            {
                case HandlerThreadOption.PublisherThread:
                    return handler;
                case HandlerThreadOption.SubscriberThread:
                    return GetCurrentThreadExecutionStrategy(handler);
                case HandlerThreadOption.BackgroundThread:
                    return GetBackgroundThreadExecutionStrategy(handler);
                default:
                    throw new ArgumentOutOfRangeException("threadOption");
            }
        }
    
        private static EventHandler GetHandler(EventHandler handler, HandlerThreadOption threadOption)
        {
            switch (threadOption)
            {
                case HandlerThreadOption.PublisherThread:
                    return handler;
                case HandlerThreadOption.SubscriberThread:
                    return GetCurrentThreadExecutionStrategy(handler);
                case HandlerThreadOption.BackgroundThread:
                    return GetBackgroundThreadExecutionStrategy(handler);
                default:
                    throw new ArgumentOutOfRangeException("threadOption");
            }
        }
    
        private static EventHandler<T> GetBackgroundThreadExecutionStrategy<T>(EventHandler<T> action)
        {
            return (sender, e) => Task.Factory.StartNew(() => action(sender, e));
        }
    
        private static EventHandler GetBackgroundThreadExecutionStrategy(EventHandler handler)
        {
            return (sender, e) => Task.Factory.StartNew(() => handler(sender, e));
        }
    
        private static EventHandler<T> GetCurrentThreadExecutionStrategy<T>(EventHandler<T> action)
        {
            var currentSynchronizationContext = SynchronizationContext.Current;
    
            return (sender, e) => PostToSynchronizationContext(currentSynchronizationContext, () => action(sender, e));
        }
    
        private static EventHandler GetCurrentThreadExecutionStrategy(EventHandler handler)
        {
            var currentSynchronizationContext = SynchronizationContext.Current;
    
            return (sender, e) => PostToSynchronizationContext(currentSynchronizationContext, () => handler(sender, e));
        }
    
        private static void PostToSynchronizationContext(SynchronizationContext synchronizationContext, Action action)
        {
            try
            {
                synchronizationContext.Post(state => action(), null);
            }
            catch (Exception ex)
            {
                if (!ex.Message.StartsWith("The operation cannot be completed because the window is being closed", StringComparison.Ordinal))
                {
                    throw;
                }
            }
        }
    }
