    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Class1();
            c1.SendCats();
        }
    }
    class Class1
    {
        public void SendCats()
        {
            var catData = new[]
            {
                new { name = "cat1", version = 1 },
                new { name = "cat2", version = 2 }
            };
            var c2 = new Class2(catData);
        }
    }
    class Class2
    {
        public Class2(dynamic[] catData)
        {
            foreach (var cat in catData)
            {
                Console.WriteLine("{0} {1}", cat.name, cat.version);
            }
        }
    }
