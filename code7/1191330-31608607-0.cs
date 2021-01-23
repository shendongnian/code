    public class DomainEvents
    {
        public static IEventHandlerFactory EventHandlerFactory { get; set; }
    
        public DomainEvents(IEventHandlerFactory factory)
        {
             EventHandlerFactory = factory;
        }
        public static void Raise<T>(T domainEvent) 
        {
            EventHandlerFactory
                .GetDomainEventHandlersFor(event)
                .ForEach(h => h.Handle(event));
        }
    }
