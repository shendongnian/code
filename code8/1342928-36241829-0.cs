    public class ApplicationDbContext : IdentityDbContext<User>
    {
    public ApplicationDbContext()
        : base("DefaultConnection")
    {
    }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Depot> Depots { get; set; }
    static ApplicationDbContext()
    {
        Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
    }
    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
    }
    public class User : IdentityUser{
      // other properties
    }
