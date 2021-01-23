        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().HasMany(b => b.Drivers).WithMany(d => d.Buses).Map(m =>
                {
                    m.MapLeftKey("BusId");
                    m.MapRightKey("DriverID");
                    m.ToTable("BusDriverJoinTable");
                });
            modelBuilder.Entity<Bus>().HasMany(b => b.Lines).WithMany(l=>l.Buses).Map(m =>
            {
                m.MapLeftKey("BusId");
                m.MapRightKey("LineID");
                m.ToTable("BusLineJoinTable");
            });
        }
