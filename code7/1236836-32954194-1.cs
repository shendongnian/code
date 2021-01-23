    public class Person
    {
        public string EnglishName { get; set; }
        public string SpanishName { get; set; }
    }
    public static class PersonDictExtensions
    {
        public static void AddPerson(this IDictionary<string, Person> persons, Person person)
    	{
    	    persons.Add(person.EnglishName, person);
    		persons.Add(person.SpanishName, person);
    	}
    	
    	public static void RemovePerson(this IDictionary<string, Person> persons, Person person)
    	{
    		foreach (var item in persons.Where(x => object.ReferenceEquals(x.Value, person)).ToList())
    		{
    		    persons.Remove(item.Key);
    		}
    	}
    }
    
    var person = new Person { EnglishName = "Foo", SpanishName = "Bar" };
    var dict = new Dictionary<string, Person>();
    dict.AddPerson(person);
    dict.RemovePerson(person);
