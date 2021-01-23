    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<User>()
                    .HasMany<Event>(s => s.Events)
                    .WithMany(c => c.Users)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("UserRefId");
                                cs.MapRightKey("EventRefId");
                                cs.ToTable("UserEvent");
                            });
    
    }
