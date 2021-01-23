     protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //Do not delete this:
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Entity<Tournament>()
                    .HasKey(e => e.TournamentId)
                    .HasRequired(e => e.Rules)
                    .WithRequiredPrincipal();
    
                modelBuilder.Entity<Tournament>()
                    .HasKey(e => e.TournamentId)
                    .HasRequired(e => e.TournamentSettings)
                    .WithRequiredDependent();
    
                modelBuilder.Entity<TournamentOrganizer>()
                    .HasKey(e => e.Id)
                    .HasRequired(e => e.Settings)
                    .WithRequiredDependent();
    
    
                modelBuilder.Entity<Tournament>().ToTable("Tournament");
                modelBuilder.Entity<TournamentRules>().ToTable("Tournament");
                modelBuilder.Entity<TournamentSettings>().ToTable("Tournament");
    
                modelBuilder.Entity<TournamentOrganizer>().ToTable("TournamentOrganizer");
                modelBuilder.Entity<TournamentOrganizerSetting>().ToTable("TournamentOrganizer");
    
               
    
            }
