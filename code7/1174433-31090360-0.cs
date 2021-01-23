    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Vehicle> Cars { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Company> Employers { get; set; }
        public DbSet<Employee> { get; set; }
    }
