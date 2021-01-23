    class Bar
    {
        public string Text { get; set; }
    }
    class Foo
    {
        public List<Bar> Bars { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo(); // Note that foo.Bars is still null
            string text = foo.Bars?.FirstOrDefault()?.Text;
            Console.WriteLine(text);
        }
    }
