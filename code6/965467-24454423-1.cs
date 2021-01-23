    public class EventPublisher<TEvent> : IEventPublisher<TEvent>
    {
        private readonly EventMediator<TEvent> mediator;
        public EventPublisher(EventMediator<TEvent> mediator) {
            this.mediator = mediator;
        }
        public void Publish(TEvent Event) {
            this.mediator.Publish(Event);
        }
    }
    public class EventSubscriber<TEvent> : IEventSubscriber<TEvent>
    {
        private readonly EventMediator<TEvent> mediator;
        public EventSubscriber(EventMediator<TEvent> mediator) {
            this.mediator = mediator;
        }
        public void Subscribe(Action<TEvent> CallBack) {
            this.mediator.Subscribe(Callback);
        }
    }
