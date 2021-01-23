    public class Enrollment 
    {
        public int EnrollmentId { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    
    public class Course 
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Need this to remove the cascade convention.
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
    }
