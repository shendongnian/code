    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Teacher>()
            .HasMany(teacher => teacher.Subjects)
            .WithMany(subject => subject.Teachers)
            .Map(c =>
            {
                c.ToTable("Teacher_Subject_Map");
                c.MapLeftKey("TeacherEmail");
                c.MapRightKey("SubjectName");
            });
    }
