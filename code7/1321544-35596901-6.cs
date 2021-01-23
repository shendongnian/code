    public abstract class AbstractClass<T> : AbstractClass where T : IConvertible
    {
        public abstract string Name { get; set; }
        public abstract T Value { get; set; }
    }
