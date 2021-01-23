    public class ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
             options.UseSqlite("Filename=./test.db");
        }
    }
