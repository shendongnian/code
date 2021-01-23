    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""A"" : ""one"", ""B"" : ""two"" }";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json);
            Console.WriteLine("A: " + (foo.A == null ? "(null)" : foo.A));
            Console.WriteLine("C: " + (foo.C == null ? "(null)" : foo.C));
        }
        class Foo
        {
            public string A { get; set; }
            public string C { get; set; }
        }
    }
