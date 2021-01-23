    public class YourDbContext : DbContext
    {
    	public DbSet<LetterEntity> LetterEntities { get; set; }
    	public DbSet<Destination> Destinations { get; set; }
    	public DbSet<LetterDestinationLink> LetterDestinationLinks { get; set; }
    }
