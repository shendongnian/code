    public DbSet<Auctions> Auctions { get; set; }
    public DbSet<Bid> Bids { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Auctions>()
       .HasOne(p => p.Signup)
       .WithMany(b => b.Auction);
       modelBuilder.Entity<Bid>()
       .HasOne(p => p.Auction)
       .WithMany(b => b.bids);
       base.OnModelCreating(modelBuilder);
    }
