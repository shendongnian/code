    class Program
    {
        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int NumberOfChildren { get; set; }
        }
        private static List<Person> people = new List<Person>()
    {
        new Person() { Name="Andrew", Age=35, NumberOfChildren=3},
        new Person() { Name="Maria",Age=33,NumberOfChildren=3},
        new Person() {Name="Tim",Age=67,NumberOfChildren=4},
        new Person() {Name="Tim",Age=62,NumberOfChildren=2},
        new Person() {Name="Jim", Age=67,NumberOfChildren=2},
        new Person() {Name="Tim",Age=33,NumberOfChildren=0},
        new Person() {Name="Bob",Age=35,NumberOfChildren =3},
        new Person() {Name="Daisy",Age=1,NumberOfChildren=0}
    };
        static void Main(string[] args)
        {
            List<string> sortConditions = new List<string>() { "Age", "Name", "NumberOfChildren" };
            var properties = GetSortProperties<Person>(sortConditions);
            people.Sort((Person a, Person b) =>
            {
                int result = 0;
                foreach (PropertyInfo prop in properties)
                {
                    result = ((IComparable)prop.GetValue(a, null)).CompareTo(prop.GetValue(b, null));
                    if (result != 0)
                        break;
                }
                return result;
            });
        }
        static List<PropertyInfo> GetSortProperties<T>(List<string> propertyNames)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();
            var typeProperties = typeof(T).GetProperties();
            foreach (string propName in propertyNames)
            {
                properties.Add(typeProperties.SingleOrDefault(tp => tp.Name == propName));
            }
            return properties;
        }
    }
