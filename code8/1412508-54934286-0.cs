    namespace Car_proj_new.Models
    {
       public class CarDbContext: DbContext
       {
          //***
          public CarDbContext(DbContextOptions<CarDbContext> options) : base (options)
           {
           }
          //***
          public DbSet<Corporations> Corporations { get; set; }
          public DbSet<PossibleFixes> PossibleFixes { get; set; }
          public DbSet<Workers> Workers { get; set; }
       }
    } 
