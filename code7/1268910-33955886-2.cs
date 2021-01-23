    public interface IDomainEvents
    {
        void Raise<T>(T args) where T : IDomainEvent;
    }
    // NOTE: DomainEvents depends on Autofac and should therefore be placed INSIDE
    // your Composition Root.
    private class AutofacDomainEvents : IDomainEvents
    {
        private readonly IComponentContext context;
        public AutofacDomainEvents(IComponentContext context) {
            if (context == null) throw new ArgumentNullException("context");
            this.context = context;
        }
        public void Raise<T>(T args) where T : IDomainEvent {
            var handlers = this.context.Resolve<IEnumerable<IHandle<T>>>();
            foreach (var handler in handlers) {
                handler.Handle(args);
            }
        }
    }
