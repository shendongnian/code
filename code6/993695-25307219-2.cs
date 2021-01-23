    public class SubscribeLastSubject<T> : ISubject<T>,IObservable<T>,IObserver<T>,IDisposable
    {
        private readonly Subject<T> subject = new Subject<T>();
        private readonly Subject<T> lastSubject = new Subject<T>();
        public void OnNext(T value)
        {
            subject.OnNext(value);
            lastSubject.OnNext(value);
        }
        public void OnError(Exception error)
        {
            subject.OnError(error);
            lastSubject.OnError(error);
        }
        public void OnCompleted()
        {
            subject.OnCompleted();
            lastSubject.OnCompleted();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return subject.Subscribe(observer);
        }
        public IDisposable SubscribeLast(IObserver<T> observer)
        {
            return lastSubject.Subscribe(observer);
        }
        public IDisposable SubscribeLast(Action<T> action)
        {
            return lastSubject.Subscribe(action);
        }
        public void Dispose()
        {
            subject.Dispose();
            lastSubject.Dispose();
        }
    }
