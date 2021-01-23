    public class PlanetContext : DbContext
    {
        public DbSet<Planet> Peoples { get; set; }
        public DbSet<Mineral> Minerals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>()
                .HasMany(p => p.Minerals)
                .WithMany(m => m.Planets)
                .Map(t => t.MapLeftKey("PlanetID")
                    .MapRightKey("MineralID")
                    .ToTable("PlanetMineral"));
        }
    }
