    public sealed class ProgressEx<T> : IProgress<T>
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly Action<T> _handler;
        private readonly SendOrPostCallback _invokeHandlers;
        public event EventHandler<T> ProgressChanged;
        public ProgressEx(SynchronizationContext syncContext)
        {
            // From Progress.cs
            //_synchronizationContext = SynchronizationContext.CurrentNoFlow ?? ProgressStatics.DefaultContext;
            _synchronizationContext = syncContext;
            _invokeHandlers = new SendOrPostCallback(InvokeHandlers);
        }
        public ProgressEx(SynchronizationContext syncContext, Action<T> handler)
            : this(syncContext)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");
            _handler = handler;
        }
        private void OnReport(T value)
        {
            // ISSUE: reference to a compiler-generated field
            if (_handler == null && ProgressChanged == null)
                return;
            _synchronizationContext.Send(_invokeHandlers, (object)value);
        }
        void IProgress<T>.Report(T value)
        {
            OnReport(value);
        }
        private void InvokeHandlers(object state)
        {
            T e = (T)state;
            Action<T> action = _handler;
            // ISSUE: reference to a compiler-generated field
            EventHandler<T> eventHandler = ProgressChanged;
            if (action != null)
                action(e);
            if (eventHandler == null)
                return;
            eventHandler((object)this, e);
        }
    }
