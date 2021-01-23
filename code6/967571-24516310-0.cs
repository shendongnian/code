    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
    
    public class Employee : Person
    {
        public string Department { get; set; }
        public string JobTitle { get; set; }
    }
    
    public class PersonConverter : CustomCreationConverter<Person>
    {
        public override Person Create(Type objectType)
        {
            return new Employee();
        }
    }
