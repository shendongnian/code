    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
    }
    public class BaseClass
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class POCO : BaseClass
    {
        public City City1 { get; set; }
        public City City2 { get; set; }
        public City City3 { get; set; }
    }
    public class Normalized<T> : BaseClass
    {
        public List<T> City { get; set; }
        public static explicit operator Normalized<T>(POCO self)
        {
            if (self == null)
                return null;
            var normal = new Normalized<T>();
            foreach (var prop in typeof(BaseClass).GetProperties())
                prop.SetValue(normal, prop.GetValue(self));
            var complexProp = typeof(Normalized<T>).GetProperties().Where(x => x.PropertyType.GetInterfaces().Any(y => y.Name == "ICollection")).First();
            complexProp.SetValue(normal, new List<T>((typeof(POCO).GetProperties().Where(x => x.Name.Contains(complexProp.Name)).Select(x => (T)x.GetValue(self)).ToList())));
                            
            return normal;
        }
    }
    public static void Main(string[] args)
    {
        var fromDB = new POCO
        {
            Age = 20,
            id = 1,
            Name = "Mike",
            City1 = new City { Name = "Moscow", Population = 10 },
            City2 = new City { Name = "London", Population = 20 },
            City3 = null
        };
        var normal = (Normalized<City>)fromDB;
        Console.WriteLine(normal.City.Select(x => x == null ? "EMPTY" : x.Name).Aggregate((a, b) => { return a + ", " + b; }));
    }
