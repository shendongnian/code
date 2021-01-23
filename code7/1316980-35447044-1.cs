    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    List<Person> people = new List<Person>();
    people.Add(new Person()
    {
        Name = "Dave",
        Age = 43
    });
    people.Add(new Person()
    {
        Name = "Wendy",
        Age = 39
    });
    foreach (Person person in People)
    {
        Console.WriteLine(person.Name) // "Dave", then "Wendy"
    }
