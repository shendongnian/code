    class Program
    {
        static void Main(string[] args)
        {
            var x = new Calculate { a = 1, b = 2 };
            var y = new Calculate { a = 10, b = 20 };
            var z = new Calculate { a = 100, b = 200 };
            var calculations = new List<Calculate>{
                new Calculate() { a = 1, b = 2 },
                new Calculate() { a = 10, b = 20 },
                new Calculate() { a = 100, b = 200 }
            };
            calculations.ForEach(c =>
            {
                c.Process();
            });
        }
    }
    class Calculate
    {
        public int a { get; set; }
        public int b { get; set; }
        public void Process()
        {
            Console.WriteLine(a + b);
        }
    }
