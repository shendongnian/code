    private class GroupedObservable<TKey, TElement> : IGroupedObservable<TKey, TElement>
    {
        private readonly IObservable<TElement> _o;
        private readonly TKey _k;
        public TKey Key { get { return _k } }
        public GroupedObservable(TKey key, IObservable<TElement> o)
        {
            _key = key;
            _o = ;
        }
        public IDisposable Subscribe(IObserver<TElement> observer) { return _o.Subscribe(observer); }
    }
    public static IGroupedObservable<TKey, TResult> Select<TKey, TSource, TResult>(this IGroupedObservable<TKey, TSource> source, Func<TSource, TResult> selector)
    {
        return new GroupedObservable<TKey, TResult>(source.Key, ((IObservable<TSource>)source).Select(selector));
    }
