    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; } <=====
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public virtual Department Department { get; set; }
               ^^^^^^^
    }
    
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
               ^^^^^^^^^^^^^^^^^^
    }
    
    public partial class EmployeeDBContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
