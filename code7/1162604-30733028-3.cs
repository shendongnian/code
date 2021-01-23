    public class Producer : IObservable<Message>
    {
        public Producer(ThirdPartyLib.Producer p)
        {
            var c = Observable.Create(observer =>
            {
                ProducerMessageHandler h = msg => observer.OnNext(msg);
                p.Attach(h);
                p.Start();
                return Disposable.Empty;
            }).Publish();
            // Connect the observable the first time someone starts
            // observing
            _stream = Observable.Create(observer =>
            {
                var subscription = c.Subscribe(observer);
                if (Interlocked.Exchange(ref _connected, 1) == 0)
                {
                    c.Connect();
                }
                return subscription;
            });
        }
        private IObservable<Message> _stream;
        // implement IObservable<T> by delegating to Rx
        public IDisposable Subscribe(IObserver<Message> observer)
        {
            return _stream.Subscribe(observer);
        }
    }
