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
        }
    }
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
