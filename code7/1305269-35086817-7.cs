    public IDbSet<Animal> Animals { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Dog>().ToTable("Dogs");
        modelBuilder.Entity<Bird>().ToTable("Birds");
    }
