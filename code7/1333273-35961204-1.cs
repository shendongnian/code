    class Foo
    {
        public Foo(int value)
        {
            this.Value = value;
        }
        public int Value { get; private set; }
        public static implicit operator Foo(int value)
        {
            return new Foo(value);
        }
    }
