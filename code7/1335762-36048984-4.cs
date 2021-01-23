    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.ReportedByUser)
                .WithMany(u => u.Issues)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Issue>()
                    .HasOne(i => i.ClosedByUser)
                    .WithMany(u => u.Issues)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
