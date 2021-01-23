    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication9
    {
    class Program
    {
        static void Main(string[] args)
        {
            var customers = Enumerable.Range(1, 10).Select(c => new Customer() { Id = c, Name = "Customer " + c });
            var filteredCustomers = StronglyNameFilter(customers, c => c.Id == 1);
            var filteredCustomers2 = StronglyNameFilter(customers, c => c.Name == "Customer 1");
            var filteredCustomers3 = ReflectionFilter(customers, "Id", 1);
            var filteredCustomers4 = ReflectionFilter(customers, "Name", "Customer 1");
            Console.ReadLine();
        }
        private static IEnumerable<T> StronglyNameFilter<T>(IEnumerable<T> collection, Func<T, bool> filter)
        {
            return collection.Where(filter).ToList();
        }
        private static IEnumerable<T> ReflectionFilter<T>(IEnumerable<T> collection, string property, object value)
        {
            if (collection.Count() == 0)
                return new List<T>();
            PropertyInfo pInfo = collection.First().GetType().GetProperty(property);
          
            return collection.Where(c => object.Equals(pInfo.GetValue(c), value)).ToList();
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    }
 
