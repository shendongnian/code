     public class NoTrackingFlymarkOfflineContext : FlymarkOfflineContext
        {
            public NoTrackingFlymarkOfflineContext() : base("FlymarkOfflineContext")
            {
                Configuration.AutoDetectChangesEnabled = false;
                Configuration.ValidateOnSaveEnabled = false;
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Viddil>()
                    .Property(p => p.ViddilIndex)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            }
        }
