    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Question>()
        .HasOne(q => q.CorrectVariant)
        .WithOne(v => v.SecondQuestion)
        .HasForeignKey<Question>(q => q.CorrectVariantId);
    
      modelBuilder.Entity<Variant>()
          .HasOne(v => v.Question)
          .WithMany(a => a.Variants).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.SetNull);
    
      base.OnModelCreating(modelBuilder);
    }
