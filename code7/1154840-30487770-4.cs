    public class OracleDbContext : DbContext
    {
        public OracleDbContext()
        {
            Database.SetInitializer<OracleDbContext>(new DropCreateDatabaseAlways<OracleDbContext>());
        }
        public DbSet<Prueba> Pruebas { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DATA");
        }
    }
