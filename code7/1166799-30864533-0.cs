    public static void Main()
    {
        var input =
        @"**Albert School**: George Branson, Eric Towson, Nancy Vanderburg; 
        **Hallowed Halls**: Ann Crabtree, Jane Goodall, Rick Grey, Tammy Hudson;
        **XXX University**: Rick Anderson, Martha Zander;";
        
        var universities = input
		                  .Split(';')
						  .Select(ParseUniversity)
						  .ToArray();
    }
    
    public static University ParseUniversity(string line)
    {
        var split = line
                   .Split(',',':')
                   .Select(f=>f.Trim('*','\n','\r', '\t' ,' '))  // remove trailing crap
                   .ToArray();
        
        var univerityName = split.First();
        
        var persons = split
                     .Skip(1)  // skip university field
                     .Select(ParsePerson)
                     .ToArray();
        
        return new University {Name = univerityName, Persons = persons};
    }
    
    public static Person ParsePerson(string field)
    {
        var p = field.Split(' ');
        return new Person{FirstName = p.First(), LastName = p.Last()};
    }
    
    public class University
    {
        public string   Name    {get;set;}
        public Person[] Persons {get;set;}
    }
    
    public class Person
    {
        public string FirstName {get;set;}
        public string LastName  {get;set;}
    }
