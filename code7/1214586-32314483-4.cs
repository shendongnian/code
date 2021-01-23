    public class Student
    {
        public int Id { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
