    public class ApplicationDbContext :  DbContext // Or what ever your database
                                                   // context has
    {
        public DbSet<PlacementOrganisation> PlacementOrganisations { get; set; }
        public DbSet<Placement> Placements { get; set; }
