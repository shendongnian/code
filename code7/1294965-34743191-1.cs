    namespace MVCDemo.Models
    {
        public class EmployeeContext:DbContext
        {
            public DbSet<Employee> employees { get; set; }
        }
    }
