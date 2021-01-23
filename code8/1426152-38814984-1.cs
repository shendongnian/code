    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<School>().HasKey(p => p.SchoolId);
        modelBuilder.Entity<Teacher>().HasKey(p => p.TeacherId);
        modelBuilder.Entity<Student>().HasKey(p => p.StudentId);
    
    
        modelBuilder.Entity<School>().HasOne<Student>(s => s.Student)
            .WithOne().HasForeignKey<School>(s => s.StudentId);
        modelBuilder.Entity<School>().HasOne<Teacher>(s => s.Teacher)
            .WithOne().HasForeignKey<School>(s => s.TeacherId);
    
    }
