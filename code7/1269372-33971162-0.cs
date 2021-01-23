    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(x => x.Id).HasColumnName("STUDENT_ID");
        modelBuilder.Entity<Teacher>().Property(x => x.Id).HasColumnName("TEACHER_ID");
    }
