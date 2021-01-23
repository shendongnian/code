    public class Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Phone {get; set;}
    }
    List<Person> people = new List<Person>()
    {
        {new Person() {FirstName="Steve", LastName="OHara", Phone="123456"}},
        {new Person() {FirstName="Mark", LastName="Noname", Phone="789012"}}
    };
