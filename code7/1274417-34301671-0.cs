    public class Customer
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
    public class Contact
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
