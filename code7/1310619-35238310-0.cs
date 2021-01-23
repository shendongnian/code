    namespace ConsoleApplication2
    {
    class Program
    {
        static void Main(string[] args)
        {
            var Data = new List<object>() { new A() { MyProperty = "abc" }, new B() { MyProperty = "cde"} };
            var Result = Data.Where(d => (d.GetType().GetProperty("MyProperty").GetValue(d) as string).Equals("abc"));
            // Result is IEnumerable<object> wich contains one A class object ;)
        }
    }
    class A
    {
        public string MyProperty { get; set; }
    }
    class B
    {
        public string MyProperty { get; set; }
    }
    }
