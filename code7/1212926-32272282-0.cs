    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? MasterId { get; set; }
        [ForeignKey("MasterId")]
        public virtual Person Master { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
