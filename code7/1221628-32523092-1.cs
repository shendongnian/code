    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //primary key, composed by a combination
        modelBuilder.Entity<Team>()
            .HasKey(i => new { i.CatId, i.DogId, i.PigId });
    
        modelBuilder.Entity<Team>()
            .HasRequired(i => i.Cat)
            .WithMany(i => i.Teams)
            .HasForeignKey(i => i.CatId)
            .WillCascadeOnDelete(false);
    
        modelBuilder.Entity<Team>()
            .HasRequired(i => i.Dog)
            .WithMany(i => i.Teams)
            .HasForeignKey(i => i.DogId)
            .WillCascadeOnDelete(false);
    
        modelBuilder.Entity<Team>()
            .HasRequired(i => i.Pig)
            .WithMany(i => i.Teams)
            .HasForeignKey(i => i.PigId)
            .WillCascadeOnDelete(false);
    
        base.OnModelCreating(modelBuilder);
    }
