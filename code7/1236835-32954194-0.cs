    public class Person
    {
        public string Name { get; set; }
    }
    
    var person = new Person { Name = "Foobar" };
    var dict = new Dictionary<string, Person>();
    dict.Add("English", person);
    dict.Add("German", person);
    dict.Add("French", person);
    
