    public class CachingEqualityComparer<T> : IEqualityComparer<T> where  T : class
    {
        public T X { get; private set; }
        public T Y { get; private set; }
        public IEqualityComparer<T> DefaultComparer = EqualityComparer<T>.Default;
        public bool Equals(T x, T y)
        {
            bool result = DefaultComparer.Equals(x, y);
            if (result)
            {
                X = x;
                Y = y;
            }
            return result;
        }
        public int GetHashCode(T obj)
        {
            return DefaultComparer.GetHashCode(obj);
        }
        public T Other(T one)
        {
            if (object.ReferenceEquals(one, X))
            {
                return Y;
            }
            if (object.ReferenceEquals(one, Y))
            {
                return X;
            }
            throw new ArgumentException("one");
        }
        public void Reset()
        {
            X = default(T);
            Y = default(T);
        }
    }
