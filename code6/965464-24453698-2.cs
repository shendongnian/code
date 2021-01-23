    public interface IEventPublisher<TEvent>
    {
        void Publish(TEvent Event);
    }
        
    public class EventPublisher<T> : IEventPublisher<T>
    {
        public readonly ISubscriptions<T> subscriptions;
        public EventPublisher(ISubscriptions<T> subscriptions)
        {
            this.subscriptions = subscriptions;
        }
        public void Publish(T Event)
        {
            foreach (var subscription in this.subscriptions)
            {
                subscription.Invoke(Event);
            }
        }
    }
