    public interface IDrivingContext
    {
        DbSet<Person> People { get; }
        DbSet<Vehicle> Cars { get; }
        DbSet<Trip> Trips { get; }
    }
    
    public interface IPayrollContext
    {
        DbSet<Person> People { get; }
        DbSet<Company> Employers { get; }
        DbSet<Employee> Employees { get; }
    }
