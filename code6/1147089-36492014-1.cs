         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MySchema"); //see [here][2]
            modelBuilder.Entity<TimeClass>().Property(p => p.StartTime).HasPrecision(6);
            modelBuilder.Entity<TimeClass>().Property(p => p.StopTime).HasPrecision(6);
        }
