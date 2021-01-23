    public class MyContext : DbContext
    {
        protected MyContext()
        {}
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<OpenCourse> OpenCourses { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OpenCourse>()
            .HasMany<Student>(p => p.Students)
            .WithRequired()
            .HasForeignKey(p => p.CourseId);
        base.OnModelCreating(modelBuilder);
    }
