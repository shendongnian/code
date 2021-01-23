    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    string json = @"{"Name":"Jon","Age":"30"}";
    
    Person x = JsonConvert.DeserializeObject<Person>(json);
    
    string name = x.Name;
