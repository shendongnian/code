    public class Contact {
        public int contactid {get;set;}
        public string name {get;set;}
    }
    .Select(c => new Contact { contactid = c.contactid, name = c.lname + ", " + c.fname})
    public Contact[] AllContacts { get; set; }
