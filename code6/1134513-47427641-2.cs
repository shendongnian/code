    public class Student
    {
        [Key]
        public int ID {get; set;}
        public ICollection<Contact> Contacts{ get; set; }
    }
    [ComplexType]
    public class Contact
    {
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string Email{get; set;}
    }
    ID
    Contacts[x]_Address?
    Contacts[x]_PhoneNumber?
    Contacts[x]_Email?
