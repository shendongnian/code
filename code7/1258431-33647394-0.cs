    class Program
    {
        private static Dictionary<int, Foo> _foos = new Dictionary<int, Foo>();
        private static Dictionary<int, Baz> _bazs = new Dictionary<int, Baz>();
        static void Main(string[] args)
        {
            Bar foo = new Foo();
            Bar baz = new Baz();
            Add(foo); // Resolves at runtime to Add(Foo f)
            Add(baz); // Resolves at runtime to Add(Baz b)
        }
        public static void Add(Bar b)
        {
            Add((dynamic)b);
        }
        private static void Add(Foo f)
        {
            _foos.Add(1, f);
        }
        private static void Add(Baz b)
        {
            _bazs.Add(1, b);
        }
    }
    class Foo : Bar
    {   
    }
    class Baz : Bar
    {
    }
    class Bar
    {
    }
