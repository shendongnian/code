    public class EventBus
    {
        private readonly Subject<Event> subject = new Subject<Event>();
        public IObservable<T> GetEventStream<T>() where T : Event
        {
            return subject.OfType<T>();
        }
        public void Publish<T>(T @event) where T : Event
        {
            subject.OnNext(@event);
        }
    }
