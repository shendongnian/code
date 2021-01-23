    class Program
    {
        public class Test
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }
        static void Main(string[] args)
        {
            var propertyInfo = typeof(Test).GetProperties();
            var propertyCount = propertyInfo.Count();
            Console.WriteLine($"Property count is {propertyCount}");
            foreach (var info in propertyInfo)
            {
                Console.WriteLine($"Property Name: {info.Name}");
            }
            Console.ReadKey();
        }
    }
