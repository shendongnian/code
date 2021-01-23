    public static class Program
    {
        public class A
        {
            public string Value { get; set; }
        }
        public static void Main(string[] args)
        {
            var keywords = new List<string>() {"A", "B", "C", "D"};
            var aas = new List<A>()
            {
                new A() {Value = "A"},
                new A() {Value = "AA"},
                new A() {Value = "B"},
                new A() {Value = "AB"}
            };
            Console.WriteLine("Before remove:");
            aas.ForEach(a => Console.WriteLine("  A.Value = {0}", a.Value));
            
            aas.RemoveAll(a => keywords.Contains(a.Value));
            Console.WriteLine("After remove:");
            aas.ForEach(a => Console.WriteLine("  A.Value = {0}", a.Value));
        }
    }
