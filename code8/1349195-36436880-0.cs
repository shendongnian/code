    public class Dispatcher : IDisposable {
        private readonly BlockingCollection<IDomainEvent> _queue = new BlockingCollection<IDomainEvent>(new ConcurrentQueue<IDomainEvent>());
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        public Dispatcher() {
            new Thread(Consume) {
                IsBackground = true
            }.Start();
        }
        private List<Action<IDomainEvent>> _subscribers = new List<Action<IDomainEvent>>();
        public void AddSubscriber(Action<IDomainEvent> sub) {
            _subscribers.Add(sub);
        }
        private void Consume() {            
            try {
                foreach (var @event in _queue.GetConsumingEnumerable(_cts.Token)) {
                    try {
                        foreach (Action<IDomainEvent> subscriber in _subscribers) {
                            subscriber(@event);
                        }
                    }
                    catch (Exception ex) {
                        // log, handle                        
                    }
                }
            }
            catch (OperationCanceledException) {
                // expected
            }
        }
        public void Publish(IDomainEvent domainEvent) {
            _queue.Add(domainEvent);
        }
        public void Dispose() {
            _cts.Cancel();
        }
    }
