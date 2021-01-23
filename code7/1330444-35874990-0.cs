    public class Person
    {
        public Person()
        {
            this.PhoneNumber = new PersonPhoneNumber();
        }
        public string Name { get; set; }
        public PersonPhoneNumber PhoneNumber { get; set; }
    }
