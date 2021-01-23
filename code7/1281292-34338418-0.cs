    public static List<Person> GetResults(string[] text)
    {
        var results = new List<Person>();
    
        foreach(var line in text)
        {
            results.Add(Person.Parse(line));
        }
    
        return results;
    }
    
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    
        public static Person Parse(string fromInputLine)
        {
            var delimPosition = fromInputLine.LastIndexOf(' ');
            var name = fromInputLine.Substring(0, delimPosition);
            var age = Convert.ToInt32(fromInputLine.Substring(delimPosition + 1));
            return new Person(name, age);
        }
    }
