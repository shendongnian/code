    modelBuilder.Entity<Employee>()
      .HasKey(e => e.EmpId)
      .Property(e => e.EmpFirstName,
        p => p.HasColumnType("varchar(50)")
         .HasMaxLength(50)
         .IsRequired())
      .Property(e => e.EmpLastName,
        p => p.HasColumnType("varchar(50)")
          .HasMaxLength(50)
          .IsRequired())
      .Property(e => e.EmpStartDate,
        p => p.HasColumnType("datetime")
          .IsRequired());
 
