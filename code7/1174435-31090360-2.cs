    public class MyContext : DbContext, IDrivingContext, IPayrollContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Vehicle> Cars { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Company> Employers { get; set; }
        public DbSet<Employee> { get; set; }
    }
