    public interface IEventDispatcher
    {
        void Dispatch(IEvent @event);
    }
    private sealed class Dispatcher : IEventDispatcher
    {
        private readonly Container container;
        public Dispatcher(Container container) {
            this.container = container;
        }
    
        public void Dispatch(IEvent @event) {
            if (@event == null) throw new ArgumentNullException("event");
			
			Type handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
            
            var handlers = this.container.GetAllInstances(handlerType);
            
            foreach (dynamic handler in handlers) {
                handler.Handle((dynamic)@event);
            }
        }
    }
