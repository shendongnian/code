    modelBuilder.Entity<Employee>()
      .HasKey(e => e.EmpId);
    modelBuilder.Entity<Employee>()
      .Property(e => e.EmpFirstName)
      .HasColumnType("varchar(50)")
      .HasMaxLength(50)
      .IsRequired();
    modelBuilder.Entity<Employee>()
      .Property(e => e.EmpLastName)
      .HasColumnType("varchar(50)")
      .HasMaxLength(50)
      .IsRequired();
    modelBuilder.Entity<Employee>()
      .Property(e => e.EmpStartDate)
      .HasColumnType("datetime")
      .IsRequired();
