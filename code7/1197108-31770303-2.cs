    public class ValueHolder<T>
    {
        public ValueHolder() { }
        public ValueHolder(T v)
        {
            Value = v;
        }
        public T Value { get; set; }
        public Type ValueType() { return typeof(T); }
    }
