    class Base { }
    class Derived : Base { }
    class Wrapper<T> where T : Base // T must be (derived from) Base
    {
        public T Value { get; }
        public Wrapper (T value) { Value = value; }
    }
