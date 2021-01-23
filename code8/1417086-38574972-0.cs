    public partial class CourseLecturers
    {
        [Key]
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Courses { get; set; }
        
        [Key]
        [ForeignKey(nameof(Lecturers))]
        public int LecturerId { get; set; }
        public Lecturers Lecturers { get; set; }
    }
