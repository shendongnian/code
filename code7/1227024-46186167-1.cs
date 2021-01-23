    public class DefaultComparer<T> : IEqualityComparer<IComponent<T>>
    {
        public bool Equals(IComponent<T> x, IComponent<T> y)
            => EqualityComparer<T>.Default.Equals(x.Data, y.Data);
        public int GetHashCode(IComponent<T> obj)
            => EqualityComparer<T>.Default.GetHashCode(obj.Data);
    }
    public class NameComparer<T> : IEqualityComparer<IComponent<T>>
    {
        public bool Equals(IComponent<T> x, IComponent<T> y)
            => string.Equals(x.Name, y.Name);
        public int GetHashCode(IComponent<T> obj)
            => (obj.Name ?? string.Empty).GetHashCode();
    }
