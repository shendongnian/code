    class MyContext : DbContext {
        static MyContext()
        {
            System.Data.Entity.Database.SetInitializer<CloseUpContext>(null); // This disables model checking
        }
        public DbSet<Movie> Movies {get; set;}
    }
