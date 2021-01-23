    public interface IObservableExceptional<T>
    {
        void Subscribe(IObserverExceptional<T> observer);
        IObservable<IExceptional<T>> Observable { get; }
    }
    public interface IObserverExceptional<T>
    {
        void OnNext(IExceptional<T> t);
        void OnCompleted();
        IObserver<IExceptional<T>> Observer { get; }
    }
    public interface IExceptional<out T> : IEnumerable<T>
    {
        bool HasException { get; }
        Exception Exception { get; }
        T Value { get; }
        string ToMessage();
        void ThrowIfHasException();
    }
