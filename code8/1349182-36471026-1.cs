    public class AutofacEventPublisher : IEventPublisher {
        private readonly IComponentContext container;
        public AutofacBusinessRuleValidator(IComponentContext container) {
            this.container = container;
        }
        public void Publish(IEvent e) {
            Type handlerInterface = typeof(IHandleEvent<>).MakeGenericType(e.GetType());
            Type handlersEnumerableType =
                typeof(IEnumerable<>).MakeGenericType(handlerInterface);
            var handlers = (IEnumerable<object>)this.container.Resolve(handlersEnumerableType);
            foreach (dynamic handler in handlers) {
                handler.Handle((dynamic)e);
            }
        }
    }
