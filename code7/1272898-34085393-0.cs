    public class Person
    {
        public string Name { get; set; }
        public string Pet { get; set; }
    }
    List<string> animals = new List<string>();
    animals.Add("donkey");
    animals.Add("horse");
    List<Person> people = new List<Person>();
    people.Add(new Person()
    {
        Name = "Marco",
        Pet = "horse"
    });
    people.Add(new Person()
    {
        Name = "John",
        Pet = "donkey"
    });
    people.Add(new Person()
    {
        Name = "Penny",
        Pet = "dog"
    });
    //result will only include people who have pets that are in the animal list.
    var res = people.Where(p => animals.Any(a => p.Pet.Contains(a)));
    foreach (var item in res)
    {
	    Console.WriteLine("{0}-{1}", item.Name, item.Pet);
    }
    Console.ReadLine();
