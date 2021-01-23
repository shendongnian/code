    public class EventPublisher : IEventPublisher
    {
    
        public EventPublisher(YourFavoriteContainer container)
        {
        }
    
    
        public void Publish<TEvent>(TEvent evt)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var handlers = scope.ResolveAll<IEventSubscriber<TEvent>>();
                foreach (var handler in handlers)
                {
                    //TODO: Handle exceptions=
                    handler.Handle(evt);
                }
            }
    
        }
    }
