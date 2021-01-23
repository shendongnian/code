    public class Producer
    {
        public Producer(ThirdPartyLib.Producer p)
        {
            Stream = Observable.Create(observer =>
            {
                ProducerMessageHandler h = msg => observer.OnNext(msg);
                var unsubscribe = Disposable.Create(() => p.Detach(h));
                p.Attach(h);
                p.Start();
                return unsubscribe;
            });
        }
        public IObservable<Message> Stream { get; private set; }
    }
