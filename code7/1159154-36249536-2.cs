    public class DomainEventDispatcher : IDomainEventDispatcher
        {
            private readonly Func<Type, object> _handlerLookup;
            
            public DomainEventDispatcher(Func<Type, object> handlerLookup)
            {
                _handlerLookup = handlerLookup;
            }
            
            public void Dispatch(IDomainEvent domainEvent)
            {
                Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handler = GetHandler(handlerType);
                if (handler != null)
                {
                    handler.Handle((dynamic)domainEvent);
                }
            }
            private dynamic GetHandler(Type filterType)
            {
                try
                {
                    object handler = _handlerLookup.Invoke(filterType);
                    return handler;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
