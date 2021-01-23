    class Program
    {
        static void Main(string[] args)
        {
            Responsible responsible = new Responsible();
            PopulatePerson(responsible, "first", "last");
            responsible.Phone = "93827382";
            responsible.Company = "Google";
        
        }
        public static void PopulatePerson(Person person, string pName, string pLastName)
        {
            person.Name = pName;
            person.LastName = pLastName;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public class Responsible : Person
    {
        public string Phone { get; set; }
        public string Company { get; set; }
    }
