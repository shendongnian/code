    public interface IEventPublisher
    {
        IObservable<TEvent> GetEvent<TEvent>();
        void Publish<TEvent>(TEvent sampleEvent);
    }
    public interface IEventPublisher<in T>
    {
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : T;
        void Publish<TEvent>(TEvent sampleEvent) where TEvent : T;
    }
