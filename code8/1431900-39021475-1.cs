    class A
    {
        public DateTime Date;
        public void Print() { Console.Write("A"); }
    }
    class B
    {
        public DateTime Date;
        public void Print() { Console.Write("B"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Generate sample data
            var r = new Random();
            var listA = Enumerable.Repeat(0, 10)
                .Select(_ => new A { Date = new DateTime(r.Next()) })
                .ToList();
            var listB = Enumerable.Repeat(0, 10)
                .Select(_ => new B { Date = new DateTime(r.Next()) })
                .ToList();
            // Combine the two lists into one of an anonymous type
            var combined = listA.Select(a => new { a.Date, Print = new Action(() => a.Print()) })
                .Concat(listB.Select(b => new { b.Date, Print = new Action(() => b.Print()) }))
                .OrderBy(c => c.Date)
                ;
            foreach (var item in combined)
            {
                item.Print();
                Console.Write(": " + item.Date);
                Console.WriteLine();
            }
        }
    }
