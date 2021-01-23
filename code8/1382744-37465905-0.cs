    public class CountSubject<T> : ISubject<T>
    {
        private readonly ISubject<T> _baseSubject;
        private int _counter;
        public int Count
        {
            get
            {
                return _counter;
            }
        }
        public CountSubject() : this(new Subject<T>())
        {
        }
        public CountSubject(ISubject<T> baseSubject)
        {
            _baseSubject = baseSubject;
        }
        public void OnCompleted()
        {
            _baseSubject.OnCompleted();
        }
        public void OnError(Exception error)
        {
            _baseSubject.OnError(error);
        }
        public void OnNext(T value)
        {
            _baseSubject.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Interlocked.Increment(ref _counter);
            return new CompositeDisposable(Disposable.Create(() => Interlocked.Decrement(ref _counter)),
                _baseSubject.Subscribe(observer));
        }
    }
