    [Table("Student")]
    public class Student
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")] public University University { get; set; }
    }
