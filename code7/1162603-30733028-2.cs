    public class Producer
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
            Stream = Observable.Create(observer =>
            {
                var subscription = c.Subscribe(observer);
                if (Interlocked.Exchange(ref _connected, 1) == 0)
                {
                    c.Connect();
                }
                return subscription;
            });
        }
        private int _connected;
        public IObservable<Message> Stream { get; private set; }
    }
