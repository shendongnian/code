    public class ContactPerson : IContact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        // etc...
    }
    
    public class ContactDetails : IContact
    {
        [ElementText("textView_4")]
        public string Title { get; set; }
    
        [ElementText("textView_6")]
        public string AcademicTitle { get; set; }
    
        [ElementText("firstname")]
        public string FirstName { get; set; }
    
        [ElementText("lastname")]
        public string LastName { get; set; }
    }
