    class Program
    {
        static void Main(string[] args)
        {
            //Responsible responsible = new Responsible()
            //{
            //    //I want here to populate with PopulatePerson the base members
            //    Phone = "93827382",
            //    Company = "Google"
            //};
            var responsible = Responsible.Populate("Glenn", "Fake", "93827382", "Google");
            //responsible
        }
        // NO LONGER NEEDED
        // ============================
        //public Person PopulatePerson(string pName, string pLastName)
        //{
        //    Person person = new Person();
        //    person.Name = pName;
        //    person.LastName = pLastName;
        //    return person;
        //}
    }
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public static TPerson Populate<TPerson>(string name, string lastname) where TPerson : Person, new()
        {
            TPerson person = new TPerson();
            person.Name = name;
            person.LastName = lastname;
            return person;
        }
    }
    public class Responsible : Person
    {
        public static Responsible Populate(string name, string lastname, string phone, string company)
        {
            var p = Responsible.Populate<Responsible>(name, lastname);
            p.Phone = phone;
            p.Company = company;
            return p;
        }
        public string Phone { get; set; }
        public string Company { get; set; }
    }
