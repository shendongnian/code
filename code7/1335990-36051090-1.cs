    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // One to many
        modelBuilder.Entity<Meal>()
            .HasMany(x => x.Courses)
            .WithRequired(x => x.Meal);
        // Many to many
        modelBuilder.Entity<Course>()
            .HasMany(x => x.Ingredients)
            .WithMany();
    }
