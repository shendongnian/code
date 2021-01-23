    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
                    .HasOptional(c=>c.ParentComment)
                    .WithMany(c=>c.Comments)
                    .HasForeignKey(c => c.ParentCommentId) 
                    .WillCascadeOnDelete(true);
    }
