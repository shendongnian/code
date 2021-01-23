    public class LazyField<T>
    {
        private static readonly Lazy<T> Default = new Lazy<T>();
        private readonly Lazy<T> _lazy;
        public LazyField() : this(Default) { }
        public LazyField(Lazy<T> lazy)
        {
            _lazy = lazy;
        }
        public override string ToString()
        {
            return _lazy.Value.ToString();
        }
        public static implicit operator T(LazyField<T> instance)
        {
            return instance._lazy.Value;
        }
    }
