    public class Student
    {
        [Key]
        public int ID {get; set;}
        public ICollection<Contact> Contacts{ get; set; }
    }
    public class Contact
    {
        [Key]
        public int ID {get; set;}
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string Email{get; set;}
    }
