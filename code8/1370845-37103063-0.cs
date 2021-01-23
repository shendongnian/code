    public class Subject
    {
        [Key]
        public string Name { get; set; }
        // This will hold the Key of Teacher
        public string TeacherEmail { get; set; }
        [ForeignKey("TeacherEmail")]
        public virtual Teacher Teacher { get; set; }
    }
    public class Teacher
    {
        /* the original properties comes here, e.g. Email */
        public string Email { get; set; }
        // Navigation property for taught subjects
        public virtual ICollection<Subject> TaughtSubjects { get; set; }
    }
