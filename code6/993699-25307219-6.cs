    public class SubscribeLastSubject<T> : ISubject<T>, IDisposable
    {
        private readonly Subject<T> subject = new Subject<T>();
        private readonly Subject<T> lastSubject = new Subject<T>();
        private IScheduler observeScheduler;
        private SynchronizationContext observerContext;
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
            return GetObservable().Subscribe(observer);           
        }
        public IDisposable SubscribeLast(IObserver<T> observer)
        {
            return GetLastObservable().Subscribe(observer);     
        }
        public IDisposable SubscribeLast(Action<T> action)
        {
            return GetLastObservable().Subscribe(action);
        }
        public SubscribeLastSubject<T> ObserveOn(IScheduler scheduler)
        {
            observeScheduler = scheduler;
            return this;
        }
        public SubscribeLastSubject<T> ObserveOn(SynchronizationContext context)
        {
            observerContext = context;
            return this;
        }
        public void Dispose()
        {
            subject.Dispose();
            lastSubject.Dispose();
        }
        private IObservable<T> GetObservable()
        {
            if (observerContext != null)
            {
                return subject.ObserveOn(observerContext);
            }
            if (observeScheduler != null)
            {
                return subject.ObserveOn(observeScheduler);
            }
            return subject;
        }
        private IObservable<T> GetLastObservable()
        {
            if (observerContext != null)
            {
                return lastSubject.ObserveOn(observerContext);
            }
            if (observeScheduler != null)
            {
                return lastSubject.ObserveOn(observeScheduler);
            }
            return lastSubject;
        }
    }
