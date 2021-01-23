        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var context=applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                for(int i = 1; i< 1000; i++)
                {
                    context.Movies.Add(new Movie
                    {
                       Genre = "Action",
                       ReleaseDate =DateTime.Today,
                       Title = "Movie "+i
                    });
                }
                context.SaveChanges();
            }
        }
        public DbSet<Movie> Movies { get; set; }
    }
