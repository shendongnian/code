    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Node>().Property(x => x.ID).HasDefaultValueSql("NEWID()");
    }
    
