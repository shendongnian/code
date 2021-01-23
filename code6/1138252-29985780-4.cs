    /// <summary>
    /// An HashSet&lt;T;gt; that, thorough a clever use of an internal
    /// comparer, can have a AddOrGet and a TryGet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashSetEx<T> : HashSet<T> where T : class
    {
        public HashSetEx()
            : base(new CachingEqualityComparer<T>())
        {
        }
        public HashSetEx(IEqualityComparer<T> comparer)
            : base(new CachingEqualityComparer<T>(comparer))
        {
        }
        public T AddOrGet(T item)
        {
            if (!Add(item))
            {
                var comparer = (CachingEqualityComparer<T>)Comparer;
                item = comparer.Other(item);
            }
            return item;
        }
        public bool TryGet(T item, out T item2)
        {
            if (Contains(item))
            {
                var comparer = (CachingEqualityComparer<T>)Comparer;
                item2 = comparer.Other(item);
                return true;
            }
            item2 = default(T);
            return false;
        }
        private class CachingEqualityComparer<T> : IEqualityComparer<T> where T : class
        {
            public WeakReference X { get; private set; }
            public WeakReference Y { get; private set; }
            private readonly IEqualityComparer<T> Comparer;
            public CachingEqualityComparer()
            {
                Comparer = EqualityComparer<T>.Default;
            }
            public CachingEqualityComparer(IEqualityComparer<T> comparer)
            {
                Comparer = comparer;
            }
            public bool Equals(T x, T y)
            {
                bool result = Comparer.Equals(x, y);
                if (result)
                {
                    X = new WeakReference(x);
                    Y = new WeakReference(y);
                }
                return result;
            }
            public int GetHashCode(T obj)
            {
                return Comparer.GetHashCode(obj);
            }
            public T Other(T one)
            {
                if (object.ReferenceEquals(one, null))
                {
                    return null;
                }
                object x = X.Target;
                object y = Y.Target;
                if (x != null && y != null)
                {
                    if (object.ReferenceEquals(one, x))
                    {
                        return (T)y;
                    }
                    else if (object.ReferenceEquals(one, y))
                    {
                        return (T)x;
                    }
                }
                return one;
            }
        }
    }
