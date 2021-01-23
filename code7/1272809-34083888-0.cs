    class A
    {
        public string P { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A[] rga =
            {
                new A { P = "One" },
                new A { P = "Two" },
                new A { P = "Three" },
            };
            foreach (string value in SelectProperty(rga, "P"))
            {
                Console.WriteLine(value);
            }
        }
        private static IEnumerable<string> SelectProperty<T>(IEnumerable<T> rga, string propertyName)
        {
            PropertyInfo pi = typeof(T).GetProperty(propertyName);
            foreach (T t in rga)
            {
                yield return (string)pi.GetValue(t);
            }
        }
    }
