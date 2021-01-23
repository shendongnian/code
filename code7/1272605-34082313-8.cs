    public interface ITracked<out T>
    {
        T Value { get; }
        bool IsObserved { get; }
        void Observe();
    }
    public class Tracked<T> : ITracked<T>
    {
        private readonly T value;
        public Tracked(T value)
        {
            this.value = value;
        }
        public T Value
        {
            get { return value; }
        }
        public bool IsObserved { get; private set; }
        public void Observe()
        {
            IsObserved = true;
        }
    }
    public interface ITrackableObservable<out T> : IObservable<ITracked<T>>
    {
        IObservable<T> Unobserved { get; }
    }
    public class TrackableObservable<T> : ITrackableObservable<T>
    {
        private readonly ISubject<T> unobserved = new Subject<T>();
        private readonly IObservable<ITracked<T>> source;
        public TrackableObservable(IObservable<T> source)
        {
            this.source = Observable
                .Create<ITracked<T>>(observer => source.Subscribe(
                    value =>
                    {
                        var trackedValue = new Tracked<T>(value);
                        observer.OnNext(trackedValue);
                        if (!trackedValue.IsObserved)
                        {
                            unobserved.OnNext(value);
                        }
                    },
                    observer.OnError,
                    observer.OnCompleted))
                .Publish()
                .RefCount();
        }
        public IObservable<T> Unobserved
        {
            get { return unobserved.AsObservable(); }
        }
        public IDisposable Subscribe(IObserver<ITracked<T>> observer)
        {
            return source.Subscribe(observer);
        }
    }
    public static class TrackableObservableExtensions
    {
        public static ITrackableObservable<T> ToTrackableObservable<T>(this IObservable<T> source)
        {
            return new TrackableObservable<T>(source);
        }
        public static IObservable<T> Observe<T>(this IObservable<ITracked<T>> source)
        {
            return source.Do(x => x.Observe()).Select(x => x.Value);
        }
        public static IObservable<T> ObserveWhere<T>(this IObservable<ITracked<T>> source, Func<T, bool> predicate)
        {
            return source.Where(x => predicate(x.Value)).Observe();
        }
    }
