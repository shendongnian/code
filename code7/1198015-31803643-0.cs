    class Foo
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rendered = new List<string>();
            if (!rendered.Contains(nameof(Foo.A)))
            {
                //Do something
                rendered.Add(nameof(Foo.A));
            }
        }
    }
