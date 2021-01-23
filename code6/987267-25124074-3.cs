    public class Person : LegalEntity {
        public Salutation Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get { return base.Name; } set { base.Name = value; } }
        // Some other members specific to a person here...
    }
