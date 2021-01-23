    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MonsterType>()
                    .HasRequired(t => t.DefendAgainst)
                    .WithMany()
                    .Map(configuration => configuration.MapKey("DefendAgainst"));
    
                modelBuilder.Entity<MonsterType>()
                   .HasRequired(t => t.ImmuneTo)
                   .WithMany()
                   .Map(configuration => configuration.MapKey("ImmuneTo"));
    
                modelBuilder.Entity<MonsterType>()
                  .HasRequired(t => t.WeakTo)
                  .WithMany()
                  .Map(configuration => configuration.MapKey("WeakTo"));
                                        
               
               base.OnModelCreating(modelBuilder);
            }
