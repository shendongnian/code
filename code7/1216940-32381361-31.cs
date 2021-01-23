    // NOTE: This class must be a singleton (there should only ever
    // be one copy; this happens automatically in any dependency injection
    // container). This class is the central dictionary that routes events
    // of any incoming type, to all listeners for that same type.
    [Export(typeof (IEventPublisher))]
    public class EventPublisher : IEventPublisher
    {
        private readonly ConcurrentDictionary<Type, object> _subjects;
        public EventPublisher()
        {
            _subjects = new ConcurrentDictionary<Type, object>();
        }
        public IObservable<TEvent> GetEvent<TEvent>()
        {
            return (ISubject<TEvent>)_subjects.GetOrAdd(typeof(TEvent), t => new Subject<TEvent>());
        }
        public void Publish<TEvent>(TEvent sampleEvent)
        {
            object subject;
            if (_subjects.TryGetValue(typeof (TEvent), out subject))
            {
                ((ISubject<TEvent>)subject).OnNext(sampleEvent);
            }
            // Could add a lock here to make it thread safe, but in practice,
            // the Dependency Injection container sets everything up once on
            // startup and it doesn't change from that point on, so it just
            // works.
        }
    }
    // NOTE: There can be many copies of this class, one for
    // each type of message. This happens automatically in any
    // dependency injection container.
    [Export(typeof (IEventPublisher<>))]
    public class EventPublisher<T> : IEventPublisher<T>
    {
        private readonly IEventPublisher _eventPublisher;
        [ImportingConstructor]
        public EventPublisher(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }
        public IObservable<TEvent> GetEvent<TEvent>() where TEvent : T
        {
            return _eventPublisher.GetEvent<TEvent>();
        }
        public void Publish<TEvent>(TEvent sampleEvent) where TEvent : T
        {
            _eventPublisher.Publish(sampleEvent);
        }
    }
