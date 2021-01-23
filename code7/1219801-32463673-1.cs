    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolDBConnectionString")
        {
            Database.SetInitializer<SchoolContext>(new SchoolDBInitializer<SchoolContext>());
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
