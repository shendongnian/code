    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new[]
            {   
                new Person {FirstName = "Hello", LastName = "World"}, 
                new Person {FirstName = "Foo", LastName = "Bar"},
            };
         
            Console.WriteLine(people.Where(FuncFactory.GetFilterFunc<Person>(FilterType.Contains, x => x.FirstName, "ello")).Any());
            Console.WriteLine(people.Where(FuncFactory.GetFilterFunc<Person>(FilterType.Equals, x => x.FirstName, "ello")).Any());
            Console.WriteLine(people.Where(FuncFactory.GetFilterFunc<Person>(FilterType.Contains, x => x.LastName, "ar")).Any());
            Console.WriteLine(people.Where(FuncFactory.GetFilterFunc<Person>(FilterType.Equals, x => x.LastName, "ar")).Any());
            Console.ReadKey();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public enum FilterType
    {
        Contains,
        Equals
    }
    public static class FuncFactory
    {
        public static Func<T, bool> GetFilterFunc<T>(FilterType filterType, Func<T, IComparable> propFunc, string filter)
        {
            switch (filterType)
            {
                case FilterType.Contains:
                    return x => (propFunc(x) as string).Contains(filter);
                case FilterType.Equals:
                    return x => (propFunc(x) as string).Equals(filter);
                default:
                    throw new ArgumentException("Invalid FilterType");
            }
        }
    }
