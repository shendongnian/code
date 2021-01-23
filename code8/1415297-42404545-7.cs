    modelBuilder.Entity<Employee>()
      .HasKey(e => e.EmpId)
      .Property(p => p.HasColumnType("varchar(50)")
        .HasMaxLength(50)
        .IsRequired(),
        e => e.EmpFirstName,
        e => e.EmpLastName);
      .Property(p => p.HasColumnType("datetime")
        .IsRequired(),
        e => e.EmpStartDate,);
