    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(IYourContainerInterface container)
        {
        }
    
        public void Publish<TEvent>(TEvent evt)
        {
            var handlers = _container.ResolveAll<TEvent>();
            foreach (var handler in handlers)
            {
                handler.Publish(evt);
            }
        }
    }
