    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        
        modelBuilder.Entity<Week>()
                    .HasMany<Day>(w => w.Days)
                    .WithOptional(d => d.Week);
        modelBuilder.Entity<WeekEnd>()
                    .HasMany<Day>(we => we.Days)
                    .WithOptional(d => d.WeekEnd);
    }
