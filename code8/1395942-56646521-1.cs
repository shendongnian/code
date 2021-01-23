     public class Yourdbcontextname: DbContext
    {
        public BridgeDB() : base("name=EFbridge")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
    }
