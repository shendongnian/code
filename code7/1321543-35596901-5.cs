    public abstract class AbstractClass<T> where T : struct, IConvertible
    {
        public abstract string Name { get; set; }
        public abstract T Value { get; set; }
    }
