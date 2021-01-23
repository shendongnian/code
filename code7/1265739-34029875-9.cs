    public partial class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=****;Database=***;user id=***;password=***");
        }
    }
