    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Post>()
            .HasMany(p => p.Comments).WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId);
    }
