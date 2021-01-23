    namespace MVCDemo.Models
    {
        public class EmployeeContext:DbContext
        {
            public DbSet<Employees> Employees { get; set; }
        }
    }
