    public class Student
    {
        [Key]
        public int ID {get; set;}
        public Contact PrimaryContact { get; set; }
        public Contact SecondaryContact{ get; set; }
    }
    [ComplexType]
    public class Contact
    {
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string Email{get; set;}
    }
