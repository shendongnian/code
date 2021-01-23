    public class EventHandlerService
    {
        public void Register(object eventSource, string eventName, Delegate handler)
        {
            // do the work here
        }
        public void Register<T>(object eventSource, string eventName, EventHandler handler)
        {
            Register(eventSource, eventName, handler);
        }
        public void Register<T>(object eventSource, string eventName, EventHandler<T> handler)
        {
            // we need cast here to help compiler to find desired overload
            Register(eventSource, eventName, (Delegate)handler);
        }
    }
