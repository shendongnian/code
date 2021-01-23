     public interface IEventFactory
     {
        IEvent Create(...);
     }
     public class CompletedEventFactory : IEventFactory
     {
        ...
        public IEvent Create(...)
        {
            return _container.Resolve<CompletedEvent>(new ParameterOverride(...));
        }
    }
    public class Service
    {
        ...
        public void DoWork()
        {
            var completedEvent = _eventFactory.Create(...);
            DomainEvents.Raise(completedEvent);
        }
    
    }
