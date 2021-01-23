    public class EventDispatcher
    {
        private readonly ILifetimeScope _scope;
        public EventDispatcher(ILifetimeScope scope)
        {
            this._scope = scope;
        }
        public virtual IMessageResults Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            var result = new MessageResults();
            var handlers = this._scope.Resolve<IEnumerable<IEventHandler<TEvent>>>().ToList();
            if (!handlers.Any())
            {
                Trace.WriteLine(String.Format("No event handlers for event {0} ", typeof(TEvent)));
                result.AddResult(new MessageResult(true));
            }
            else
            {
                foreach (var eventHandler in handlers.Where(h => h.Handles(@event as IDomainEvent)))
                {
                    eventHandler.Handle(@event);
                }
            }
            return result;
        }
        public int EventHandlerCount
        {
            get
            {
                // not tested 
                var handlerCount = this._scope.ComponentRegistry
                                              .Registrations
                                              .Where(r => r.Services
                                                         .OfType<IServiceWithType>()
                                                         .Any(swt => swt.ServiceType.IsGenericType
                                                                     && swt.ServiceType.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                                              .Count();
                return handlerCount;
            }
        }
    }
