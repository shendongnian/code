    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    //get the list of bad guys
    List<Person> badGuys = ...
    using(Context c = new Context())
    {
       //enumerate Persons, then exclude badPersons
       var goodPersons = c.Persons.ToList().Except(badPersons);
    }
