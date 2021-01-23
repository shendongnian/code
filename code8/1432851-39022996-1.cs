        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestFactory>().ToTable("RestaurantGuest");
            modelBuilder.Entity<Visit>()
                .HasRequired(v => v.Guest)
                .WithMany()
                .HasForeignKey(v => v.GuestId);
        }
