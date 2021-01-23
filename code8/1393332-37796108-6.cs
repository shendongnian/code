    public class EmployeeMap : EntityTypeConfiguration<EmployeeEFEntity>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeUUID);
            this.Property(t => t.EmployeeUUID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
            this.Property(t => t.TheVersionProperty)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();
            this.Property(t => t.SSN)
                .IsRequired()
                .HasMaxLength(11);
            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(64);
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(64);
            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(t => t.EmployeeUUID).HasColumnName("EmployeeUUID");
            this.Property(t => t.ParentDepartmentUUID).HasColumnName("ParentDepartmentUUID");
            this.Property(t => t.TheVersionProperty).HasColumnName("TheVersionProperty");
            this.Property(t => t.SSN).HasColumnName("SSN");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.HireDate).HasColumnName("HireDate");
            // Relationships
            this.HasMany(t => t.MyParkingAreas)
                .WithMany(t => t.MyEmployees)
                .Map(m =>
                {
                    m.ToTable("EmployeeParkingAreaLink");
                    m.MapLeftKey("TheEmployeeUUID");
                    m.MapRightKey("TheParkingAreaUUID");
                });
            this.HasRequired(t => t.ParentDepartment)
                .WithMany(t => t.Employees)
                .HasForeignKey(d => d.ParentDepartmentUUID);
        }
    }
