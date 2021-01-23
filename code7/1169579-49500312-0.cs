    public class X
    {
        public X(One first, string foo)
        {
            First = first;
            Foo = foo;
        }
        public One First { get; }
        public string Foo { get; }
    }
    public class One
    {
        public One(Two second, int bar)
        {
            Second = second;
            Bar = bar;
        }
        public Two Second { get; }
        public int Bar { get; }
    }
    public class Two
    {
        public Two(string third, bool baz)
        {
            Third = third;
            Baz = baz;
        }
        public string Third { get; }
        public bool Baz { get; }
    }
