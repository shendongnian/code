        public StudentMap()
        {
                HasMany(p => p.Teachers)
                .WithMany(p => p.Students)
                .Map(m =>
                {
                    m.ToTable("StudentsTeachers", "School");
                    m.MapLeftKey("Student_ID");
                    m.MapRightKey("Teacher_ID");
                });
        }
