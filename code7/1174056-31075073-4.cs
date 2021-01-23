    public class OptionalRef<T>
    {
        public T Value { get; set; }
        public static implicit operator OptionalRef<T>(T value)
        {
            return new OptionalRef<T> { Value = value };
        }
        public static implicit operator T(OptionalRef<T> optional)
        {
            return optional.Value;
        }
        public override string ToString()
        {
            return Value != null ? Value.ToString() : null;
        }
    }
