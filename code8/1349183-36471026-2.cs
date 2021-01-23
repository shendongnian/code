    public class AutofacEventPublisher : IEventPublisher {
        private readonly IComponentContext container;
        public AutofacBusinessRuleValidator(IComponentContext container) {
            this.container = container;
        }
        public void Publish(IEvent e) {
            foreach (dynamic handler in this.GetHandlers(e.GetType())) {
                handler.Handle((dynamic)e);
            }
        }
        
        private IEnumerable GetHandlers(Type eventType) =>
            (IEnumerable)this.container.Resolve(
                typeof(IEnumerable<>).MakeGenericType(
                    typeof(IHandleEvent<>).MakeGenericType(eventType)));
    }
