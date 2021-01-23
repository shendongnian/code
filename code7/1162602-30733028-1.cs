    public class Producer : IObservable<Message>
    {
        public Producer(ThirdPartyLib.Producer p)
        {
            _stream = Observable.Create(observer =>
            {
                ProducerMessageHandler h = msg => observer.OnNext(msg);
                var unsubscribe = Disposable.Create(() => p.Detach(h));
                p.Attach(h);
                p.Start();
                return unsubscribe;
            });
        }
        private IObservable<Message> _stream;
        // implement IObservable<T> by delegating to Rx
        public IDisposable Subscribe(IObserver<Message> observer)
        {
            return _stream.Subscribe(observer);
        }
    }
