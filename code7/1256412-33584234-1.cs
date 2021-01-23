    public partial class Employee
    {
        public Employee()
        {
            Subordinates = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
    }
    
    public class EmployeeConfiguration: EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("EmployeeDbContext", "dbo");
            HasKey(p => p.Id).Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Name).HasMaxLength(50);
            HasMany(p => p.Subordinates).WithOptional(p => p.Manager)
                                     .HasForeignKey(p => p.ManagerId);
        }
    }
