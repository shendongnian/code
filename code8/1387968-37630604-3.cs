    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name + ", " + Age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person {Name = "yacoub", Age = 30},
                new Person {Name = "yacoub", Age = 32},
                new Person {Name = "adam", Age = 30},
                new Person {Name = "adam", Age = 33},
            };
            var query = MyClass.Order(
                persons.AsQueryable(),
                new List<string> { "+Name", "-Age" },
                new Dictionary<string, LambdaExpression>
                {
                    {"Name", (Expression<Func<Person, string>>) (x => x.Name)},
                    {"Age", (Expression<Func<Person, int>>) (x => x.Age)}
                });
            var result = query.ToList();
        }
    }
