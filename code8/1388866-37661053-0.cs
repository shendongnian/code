    public class ContactInfo {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstLastName { get { return FirstName + " " + LastName; }}
    }
