    public class Person
    {
        public int PersonId { get; set; }
        [Required] // == NOT NULL
        public string Name { get; set; }
        // demais... (the rest)
    }
    
    public class Professor // no inheritance!
    {
        public int ProfessorId { get; set; }
        [Required]
        public string Education { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
