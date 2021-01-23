    public interface IEventSubscriber<TEvent>
    {
        void Subscribe(Action<TEvent> CallBack);
    }
    public class EventSubscriber<T> : IEventSubscriber<T>
    {
        public readonly ISubscriptions<T> subscriptions;
        public EventSubscriber(ISubscriptions<T> subscriptions)
        {
            this.subscriptions = subscriptions;
        }
        public void Subscribe(Action<T> CallBack)
        {
            this.subscriptions.Add(CallBack);
        }
    }
