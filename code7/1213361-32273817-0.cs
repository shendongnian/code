    void Main()
    {
    	string json = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
    	
    	var result = JsonConvert.DeserializeObject<RootObject>(json);
    	
    	var firstNames = result.People.Select (p => p.FirstName).ToList();
    	var lastNames = result.People.Select (p => p.LastName).ToList();
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class RootObject
    {
        public List<Person> People { get; set; }
    }
