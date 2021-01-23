        public class EmployeeDBContext : DbContext
        {
            public EmployeeDBContext() : base("EmployeeDB") { }
    
            public DbSet<Employee> Employee { get; set; }
            public DbSet<Department> Department { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Department>().ToTable("Departments").HasKey(x => x.DepartmentId);
                modelBuilder.Entity<Employee>().ToTable("Employees").HasKey(x => x.Id);
                //ForeignKey mapping 
                modelBuilder.Entity<Employee>().HasRequired(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);
                base.OnModelCreating(modelBuilder);
            }
        }
----------
        //Domain Entity
        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Department Department { get; set; }
            public int DepartmentId { get; set; }
        }
        //Domain Entity
        public class Department
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        } 
    }
    
