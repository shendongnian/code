    public interface IEventHandler
    {
        Boolean Handles(IDomainEvent @event);
    }
    public interface IEventHandler<TEvent> : IEventHandler 
        where TEvent : IDomainEvent
    {
        void Handle(TEvent @event);
        Task HandleAsync(TEvent @event);
    }
