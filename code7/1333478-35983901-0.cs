    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("({0}) {1}", this.Id, this.Name);
        }
    }
    public class Child : Person
    {
        public int Grade { get; set; }
        public override string ToString()
        {
            return String.Format("({0}) {1} - {2}", this.Id, this.Name, this.Grade);
        }
    }
    public static void Main()
    {
        IEnumerable<Person> persons = Enumerable.Range(0, 3).Select(i => new Person()
        {
            Id = i,
            Name = "Person " + i.ToString(),
        });
        IEnumerable<Child> children = Enumerable.Range(0, 4).Select(i => new Child()
        {
            Id = i,
            Name = "Child " + i.ToString(),
            Grade = i+6,
        });
        foreach (var x in persons.Concat(children))
        {
            Console.WriteLine(x);
        }
    }
