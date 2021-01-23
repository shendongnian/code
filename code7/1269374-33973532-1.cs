    // Make all properties UPPER_CASE
    modelBuilder.Properties()
                .Configure(x => x.HasColumnName(Regex.Replace(x.ClrPropertyInfo.Name, "(?<=.)(?=[A-Z])", "_").ToUpper()));
    // Set the ID columns to ENTITY_ID
    modelBuilder.Entity<Course>()
        .ToTable("COURSE")
        .Property(x => x.Id)
        .HasColumnName("STUDENT_ID");
