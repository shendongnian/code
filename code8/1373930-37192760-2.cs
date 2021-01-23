    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseCategory>()
            .HasKey(t => new { t.ExerciseId, t.CategoryId });
        modelBuilder.Entity<ExerciseCategory>()
            .HasOne(pt => pt.Exercise)
            .WithMany(p => p.ExerciseCategories)
            .HasForeignKey(pt => pt.ExerciseId);
        modelBuilder.Entity<ExerciseCategory>()
            .HasOne(pt => pt.Category)
            .WithMany(t => t.ExerciseCategories)
            .HasForeignKey(pt => pt.CategoryId);
    }
