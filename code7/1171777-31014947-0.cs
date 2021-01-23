    public class Person
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
    }
    
    // Instantiate Person
    
    var person = new Person { firstName = "Albert", lastName = "Einstein" };
    
    // We can print fullname of the above person as follows
    
    Console.WriteLine("Full name - " + person.firstName + " " + person.lastName);
    Console.WriteLine("Full name - {0} {1}", person.firstName, person.lastName);
    Console.WriteLine($"Full name - {person.firstName} {person.lastName}");
