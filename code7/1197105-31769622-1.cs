    public class ValueTypeBase
    {
        public Type ValueType { get; set; }
    }
    public class ValueHolder<T> : ValueTypeBase
    {
        public T Value { get; set; }
    }
