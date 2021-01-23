    public class EventForwarder
    {
        private readonly RootEventSource rootEventSource;
        public EventForwarder(RootEventSource rootEventSource)
        {
            this.rootEventSource = rootEventSource;
        }
        public event Signal AnotherEvent
        {
            add { this.rootEventSource.RootEvent += value; }
            remove { this.rootEventSource.RootEvent -= value; }
        }
    }
