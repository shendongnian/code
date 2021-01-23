    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent;
    }
    private sealed class Dispatcher : IEventDispatcher
    {
        private readonly Container container;
        public Dispatcher(Container container) {
            this.container = container;
        }
    
        public static void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent {
            if (@event == null) throw new ArgumentNullException("event");
            
            var handlers = this.container.GetAllInstances<IEventHandler<TEvent>>();
            
            foreach (var handler in handlers) {
                handler.Handle(@event);
            }
        }
    }
